﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class Payment : Entity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }
        public Guid ParkingPlaceId { get; set; }
        public Guid ParkingId { get; set; }
        public string CarId { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }

    }
}