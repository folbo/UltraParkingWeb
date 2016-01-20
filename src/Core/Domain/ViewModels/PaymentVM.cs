using System;

namespace Ultra.Core.Domain.ViewModels
{
    public class PaymentVM
    {
        public string DriverName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ParkingName { get; set; }
        public decimal Price { get; set; }
        public TimeSpan BookingTime => EndTime - StartTime;
    }
}