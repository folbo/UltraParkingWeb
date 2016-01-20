using System;
using System.Collections.Generic;
using System.Linq;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class ParkingSegment : IEntity
    {
        protected ParkingSegment()
        {
            Places = new List<ParkingPlace>();
        }

        public Guid ParkingId { get; protected set; }
        public string Name { get; protected set; }
        public virtual ICollection<ParkingPlace> Places { get; protected set; }
        public virtual Parking Parking { get; protected set; }
        public Guid Id { get; set; }

        public void Rename(string newName)
        {
            Name = newName;
        }

        public static ParkingSegment Create(Parking parking, string name, int amountPlaces, Guid newId)
        {
            var segment = new ParkingSegment
            {
                ParkingId = parking.Id,
                Parking = parking,
                Name = name,
                Id = newId
            };
            for (var i = 0; i < amountPlaces; i++)
            {
                segment.Places.Add(ParkingPlace.Create(segment));
            }
            return segment;
        }

        public void Resize(int amountPlaces)
        {
            var placesDiff = amountPlaces - Places.Count;
            if (placesDiff >= 0)
            {
                for (var i = 0; i < placesDiff; i++)
                {
                    Places.Add(ParkingPlace.Create(this));
                }
            }
            else
            {
                foreach (var place in Places.OrderByDescending(p => p.Number).Take(-placesDiff))
                {
                    Places.Remove(place);
                }
            }

            Parking.Update();
        }
    }
}