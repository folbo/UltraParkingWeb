using System;
using System.Collections.Generic;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class Driver : IEntity
    {
        protected Driver()
        {
            Payments = new List<DriverPayment>();
        }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        /// <summary>
        ///     środki na koncie
        /// </summary>
        public decimal Currency { get; protected set; }

        /// <summary>
        ///     rejestracja samochodowa
        /// </summary>
        public string CarId { get; protected set; }

        public ICollection<DriverPayment> Payments { get; protected set; }
        public Guid Id { get; protected set; }

        public void AddPayment(DateTime startTime, DateTime endTime, Guid parkingPlaceId, Guid parkingId, decimal price)
        {
            Currency -= price;
            var payment = DriverPayment.Create(this, startTime, endTime, parkingPlaceId, parkingId, price);
            Payments.Add(payment);

            //if (Currency<0){DomainEvents.Tell();} todo
        }

        public static Driver Create(Guid id, string carId, string firstName, string lastName)
        {
            return new Driver
            {
                Id = id,
                CarId = carId,
                Currency = 0,
                FirstName = firstName,
                LastName = lastName
            };
        }

        public void UpdateCarId(string carId)
        {
            CarId = carId;
        }

        public void UpdateFirstName(string firstname)
        {
            FirstName = firstname;
        }

        public void UpdateLastName(string lastname)
        {
            LastName = lastname;
        }
    }
}