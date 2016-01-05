using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using Ultra.Core.Domain.Entities;

namespace Ultra.Core.Domain.DTO
{
    public class ParkingDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalPlaces { get; set; }
        public int FreePlaces { get; set; }
        public Guid OwnerId { get; set; }
        public double? LocationLatitude { get; set; }
        public double? LocationLongitude { get; set; }
    }
}
