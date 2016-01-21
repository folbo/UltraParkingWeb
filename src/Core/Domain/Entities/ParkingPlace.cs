using System;
using Ultra.Core.Domain.Events;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class ParkingPlace : IEntity
    {
        protected ParkingPlace()
        {
        }

        public Guid SegmentId { get; set; }
        public Guid ParkingId { get; set; }
        public virtual ParkingSegment Segment { get; set; }
        public virtual Parking Parking { get; set; }
        public Status Status { get; set; }
        public DateTime? StartTime { get; set; }
        public Guid? DriverId { get; set; }
        public int Number { get; set; }
        public Guid Id { get; set; }

        public static ParkingPlace Create(ParkingSegment segment)
        {
            return new ParkingPlace
            {
                Id = Guid.NewGuid(),
                Segment = segment,
                SegmentId = segment.Id,
                Parking = segment.Parking,
                ParkingId = segment.ParkingId,
                Status = Status.Free,
                Number = segment.Places.Count
            };
        }

        public void Book(Guid driverId)
        {
            if (Status != Status.Free)
            {
                throw new InvalidOperationException();
            }
            Status = Status.Reserved;
            StartTime = DateTime.UtcNow;
            DriverId = driverId;
            Parking.Update();
        }

        public void MarkAsBusy()
        {
            if (Status == Status.Busy)
            {
                throw new InvalidOperationException();
            }

            if (Status == Status.Free)
            {
                StartTime = DateTime.UtcNow;
            }
            Status = Status.Busy;

            Parking.Update();
        }

        public void MarkAsFree()
        {
            if (DriverId != null)
            {
                DomainEvents.Tell(new ParkingPlaceHasBeenReleased(StartTime.Value, DateTime.UtcNow, Id, DriverId.Value,
                    ParkingId));
            }
            Status = Status.Free;
            StartTime = null;
            DriverId = null;

            Parking.Update();
        }

        public void MarkAsReserved()
        {
            if (Status != Status.Free)
            {
                throw new NotSupportedException();
            }
            Status = Status.Reserved;
            StartTime = DateTime.UtcNow;

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