using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class Driver : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        /// <summary>
        /// środki na koncie
        /// </summary>
        public int Currency { get; set; }
        /// <summary>
        /// rejestracja samochodowa
        /// </summary>
        public string CarId { get; set; }
    }
}
