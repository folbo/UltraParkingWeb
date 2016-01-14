using System;

namespace Ultra.Core.Domain.ViewModels
{
    public class ParkingInfoVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}