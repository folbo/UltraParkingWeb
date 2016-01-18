using System;
using System.Collections.Generic;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class Driver : IEntity
    {
        protected Driver()
        {
        }

        public Guid Id { get; protected set; }
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


        public void AddPayment(DateTime startTime, DateTime endTime, Guid parkingPlaceId, Guid parkingId, decimal price)
        {
            Currency -= price;
            var payment = DriverPayment.Create(this,startTime,endTime,parkingPlaceId,parkingId,price);
            Payments.Add(payment);

            //if (Currency<0){DomainEvents.Tell();} todo
        }
    }
}