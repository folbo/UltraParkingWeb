using System;

namespace Ultra.Core.Domain.ViewModels
{
    public class ParkingSegmentVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PlacesCount { get; set; }
    }
}