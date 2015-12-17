using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class Parking : Entity 
    {
        public Parking()
        {
            Places = new List<Place>();
        }

        public virtual string Name { get; set; }
        public virtual int TotalPlaces { get; set; }
        public virtual int FreePlaces { get; set; }
        public virtual IList<Place> Places { get; set; } 
        //public virtual location Location { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual DbGeography Location { get; set; }
    }
}
