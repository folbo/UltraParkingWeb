using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class Parking : Entity 
    {
        public virtual int TotalPlaces { get; set; }
        public virtual int FreePlaces { get; set; }
        public virtual IList<Place> places { get; set; } 
        //public virtual location Location { get; set; }
        public virtual Owner Owner { get; set; }

    }
}
