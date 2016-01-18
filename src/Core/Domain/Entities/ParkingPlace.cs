﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Domain.Events;
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

        public void Book(Guid driverId)
        {
            if (Status != Status.Free)
            {
                throw new InvalidOperationException();
            }
            Status = Status.Reserved;
            StartTime = DateTime.UtcNow;
            this.DriverId = driverId;
            Parking.Update();
        }

        public void MarkAsBusy(Guid driverId)
        {
            if (Status == Status.Busy)
            {
                throw new InvalidOperationException();
            }

            if (Status == Status.Free)
            {
                StartTime = DateTime.UtcNow;
                this.DriverId = driverId;
            }
            if (DriverId != driverId)
            {
                throw new InvalidOperationException();
            }
            Status = Status.Busy;

            Parking.Update();
        }

        public void MarkAsFree()
        {
            if (DriverId != null)
            {
               DomainEvents.Tell(new ParkingPlaceHasBeenReleased(StartTime.Value,DateTime.UtcNow,Id,DriverId.Value)); 
            }
            Status = Status.Free;
            StartTime = null;
            DriverId = null;

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