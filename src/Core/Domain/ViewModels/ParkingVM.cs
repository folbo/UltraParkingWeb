using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using Ultra.Core.Domain.Entities;

namespace Ultra.Core.Domain.ViewModels
{
    public class ParkingVM
    {
        public ParkingVM()
        {
            Segments=new List<ParkingSegmentVM>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<ParkingSegmentVM> Segments { get; set; } 
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
