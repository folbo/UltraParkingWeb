using System;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class DriverPayment : IEntity
    {
        protected DriverPayment()
        {
        }

        public Guid DriverId { get; protected set; }
        public Driver Driver { get; protected set; }
        public DateTime StartTime { get; protected set; }
        public DateTime EndTime { get; protected set; }
        public Guid ParkingPlaceId { get; protected set; }
        public Guid ParkingId { get; protected set; }
        public decimal Price { get; protected set; }
        public Guid Id { get; protected set; }

        public static DriverPayment Create(Driver driver, DateTime startTime, DateTime endTime, Guid parkingPlaceId,
            Guid parkingId, decimal price)
        {
            return new DriverPayment
            {
                Id = Guid.NewGuid(),
                DriverId = driver.Id,
                Driver = driver,
                StartTime = startTime,
                EndTime = endTime,
                ParkingPlaceId = parkingPlaceId,
                ParkingId = parkingId,
                Price = price
            };
        }
    }
}