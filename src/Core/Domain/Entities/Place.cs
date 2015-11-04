using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class Place : Entity
    {
        public virtual Status Status { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual Driver Driver { get; set; }
    }

    public enum Status
    {
        Free,
        Reserved,
        Busy
    }
}
