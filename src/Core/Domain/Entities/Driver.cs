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
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        /// <summary>
        /// środki na koncie
        /// </summary>
        public virtual int Currency { get; set; }
        /// <summary>
        /// rejestracja samochodowa
        /// </summary>
        public virtual string CarId { get; set; }
        /// <summary>
        /// lista płatności
        /// </summary>
        public virtual IList<Payment> Payments { get; set; }
    }
}
