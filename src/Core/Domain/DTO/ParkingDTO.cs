using System;

namespace Ultra.Core.Domain.DTO
{
    public class ParkingDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalPlacesCount { get; set; }
        public int FreePlacesCount { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; }
        public double? LocationLatitude { get; set; }
        public double? LocationLongitude { get; set; }
    }
}