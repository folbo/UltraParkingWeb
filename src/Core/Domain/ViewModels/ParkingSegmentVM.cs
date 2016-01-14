using System;
using System.Collections.Generic;

namespace Ultra.Core.Domain.ViewModels
{
    public class ParkingSegmentVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PlacesCount { get; set; }
    }
}