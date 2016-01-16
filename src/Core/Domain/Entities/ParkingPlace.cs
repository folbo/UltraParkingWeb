using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class ParkingPlace : Entity
    {
        protected ParkingPlace()
        {
        }

        public Status Status { get; set; }
        public DateTime? StartTime { get; set; }
        public Guid? DriverId { get; set; }
        public Guid ParkingId { get; set; }
        public Guid SegmentId { get; set; }
        public virtual Parking Parking { get; set; }
        public virtual ParkingSegment Segment { get; set; }
        public int Number { get; set; }

        public static ParkingPlace Create(ParkingSegment segment)
        {
            return new ParkingPlace()
            {
                Id = Guid.NewGuid(),
                Segment = segment,
                SegmentId = segment.Id,
                Parking = segment.Parking,
                ParkingId = segment.ParkingId,
                Status = Status.Free,
                Number = segment.Places.Count,
            };
        }

        public void Book()
        {
            if (Status != Status.Free)
            {
                throw new InvalidOperationException();
            }
            Status = Status.Reserved;
            Parking.Update();
        }
    }

    public enum Status
    {
        Free,
        Reserved,
        Busy
    }
}