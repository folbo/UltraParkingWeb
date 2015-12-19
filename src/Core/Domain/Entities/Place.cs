using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class Place : Entity
    {
        public Status Status { get; set; }
        public DateTime? StartTime { get; set; }
        public Guid DriverId { get; set; }
        public Guid ParkingId { get; set; }
        public virtual Parking Parking { get; set; }
    }

    public enum Status
    {
        Free,
        Reserved,
        Busy
    }
}
