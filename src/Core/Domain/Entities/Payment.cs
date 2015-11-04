using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class Payment : Entity
    {
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual decimal Price { get; set; }
        public virtual Place ParkingSpot { get; set; }
        public virtual Parking Parking { get; set; }
    }
}
