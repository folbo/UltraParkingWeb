﻿using System;
using Ultra.Core.Domain.Entities;

namespace Ultra.Core.Domain.ViewModels
{
    public class ParkingPlaceVM
    {
        public Guid Id { get; set; }
        public Guid SegmentId { get; set; }
        public Guid ParkingId { get; set; }
        public Status Status { get; set; }
        public DateTime? StartTime { get; set; }
        public int Number { get; set; }
        public string SegmentName { get; set; }
    }
}