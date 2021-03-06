﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class Parking : IEntity
    {
        protected Parking()
        {
            Segments = new List<ParkingSegment>();
        }

        public string Name { get; protected set; }
        public int TotalPlacesCount { get; protected set; }
        public int FreePlacesCount { get; protected set; }
        public virtual ICollection<ParkingSegment> Segments { get; protected set; }
        public Guid OwnerId { get; protected set; }
        public string OwnerName { get; protected set; }
        public DbGeography Location { get; protected set; }
        public virtual IEnumerable<ParkingPlace> Places => Segments.SelectMany(s => s.Places);

        public virtual IEnumerable<ParkingPlace> FreePlaces
            => Segments.SelectMany(s => s.Places).Where(place => place.Status == Status.Free);

        public Guid Id { get; protected set; }

        public static Parking Create(string name, Guid newId)
        {
            var parking = new Parking
            {
                Name = name,
                Id = newId
            };
            parking.Update();
            return parking;
        }

        internal void Update()
        {
            TotalPlacesCount = Places.Count();
            FreePlacesCount = FreePlaces.Count(p => p.Status == Status.Free);
        }

        public void Rename(string newName)
        {
            Name = newName;
        }

        public void UpdateLocation(double latitude, double longitude)
        {
            Location =
                DbGeography.FromText(
                    $"Point({longitude.ToString(CultureInfo.InvariantCulture)} {latitude.ToString(CultureInfo.InvariantCulture)} )");
        }

        public void AddSegment(string name, int amountPlaces, Guid newId)
        {
            var segment = ParkingSegment.Create(this, name, amountPlaces, newId);
            Segments.Add(segment);
            Update();
        }

        public void RemoveSegment(Guid segmentId)
        {
            Segments.Remove(Segments.First(s => s.Id == segmentId));
            Update();
        }

        public ParkingPlace BookPlace(Guid driverId)
        {
            if (FreePlacesCount == 0)
            {
                return null;
            }
            var r = new Random();
            var parkingPlace = FreePlaces.ElementAt(r.Next(0, FreePlaces.Count()));
            parkingPlace.Book(driverId);
            return parkingPlace;
        }

        public void SetOwner(Guid newOwnerId, string ownerName)
        {
            OwnerId = newOwnerId;
            OwnerName = ownerName;
        }

        public void UpdateOwnerName(string newName)
        {
            OwnerName = newName;
        }
    }
}