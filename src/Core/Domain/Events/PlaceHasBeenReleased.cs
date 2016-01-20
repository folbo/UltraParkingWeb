using System;
using Ultra.Core.Infrastructure.Events;

namespace Ultra.Core.Domain.Events
{
    public class ParkingPlaceHasBeenReleased : IEvent
    {
        public ParkingPlaceHasBeenReleased(DateTime @from, DateTime to, Guid parkingPlaceId, Guid driverId,
            Guid parkingId)
        {
            EventId = Guid.NewGuid();
            From = from;
            To = to;
            ParkingPlaceId = parkingPlaceId;
            DriverId = driverId;
            ParkingId = parkingId;
        }

        public DateTime From { get; }
        public DateTime To { get; }
        public Guid ParkingPlaceId { get; }
        public Guid DriverId { get; }
        public Guid ParkingId { get; set; }
        public Guid EventId { get; }
    }
}