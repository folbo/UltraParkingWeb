using System;

namespace Ultra.Core.Domain.DTO
{
    public class PaymentDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ParkingName { get; set; }
        public decimal Price { get; set; }
    }
}