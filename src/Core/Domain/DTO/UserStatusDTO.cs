using System;

namespace Ultra.Core.Domain.DTO
{
    public class UserStatusDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        ///     środki na koncie
        /// </summary>
        public decimal Currency { get; set; }

        /// <summary>
        ///     rejestracja samochodowa
        /// </summary>
        public string CarId { get; set; }

        /// <summary>
        /// Podaje id parkingu w którym rezerwujemy miejsce, jeżeli nie rezerwujemy wartość jest nulem
        /// </summary>
        public Guid? ReserverParkingId { get; set; }
    }
}