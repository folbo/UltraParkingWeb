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
        public string Name { get; set; }
        public int TotalPlaces { get; set; }
        public int FreePlaces { get; set; }
        public virtual IList<Place> Places { get; set; } 
        public Guid OwnerId { get; set; }
        public DbGeography Location { get; set; }
    }
}
