using System;
using System.Collections;
using System.Collections.Generic;

namespace Ultra.Core.Domain.ViewModels
{
    public class ParkingWithPlacesVM
    {
        public ParkingWithPlacesVM()
        {

        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<ParkingPlaceVM> Places { get; set; }
    }
}