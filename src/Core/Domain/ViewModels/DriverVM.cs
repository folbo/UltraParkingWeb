using System;

namespace Ultra.Core.Domain.ViewModels
{
    public class DriverVM
    {
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
    }
}

