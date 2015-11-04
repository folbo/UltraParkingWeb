using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class Owner : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<Parking> Parkings { get; set; } 
    }
}
