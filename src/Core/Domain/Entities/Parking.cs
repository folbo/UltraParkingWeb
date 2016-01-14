using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class Parking : Entity
    {
        protected Parking()
        {
            Segments = new List<ParkingSegment>();
        }

        public string Name { get; protected set; }
        public int TotalPlaces { get; protected set; }
        public int FreePlaces { get; protected set; }
        public virtual ICollection<ParkingSegment> Segments { get; protected set; }
        public virtual IEnumerable<ParkingPlace> Places => Segments.SelectMany(s => s.Places);
        public Guid OwnerId { get; protected set; }
        public DbGeography Location { get; protected set; }

        public static Parking Create(string name, Guid newId)
        {
            var parking = new Parking()
            {
                Name = name,
                Id = newId,
            };
            parking.Update();
            return parking;
        }

        internal void Update()
        {
            TotalPlaces = Places.Count();
            FreePlaces = Places.Count(p => p.Status == Status.Free);
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

        public void AddSegment(string name, int amountPlaces,Guid newId)
        {
            var segment = ParkingSegment.Create(this,name,amountPlaces,newId);
            Segments.Add(segment);
            Update();
        }


        public void RemoveSegment(Guid segmentId)
        {
            Segments.Remove(Segments.First(s => s.Id == segmentId));
            Update();
        }
    }
}