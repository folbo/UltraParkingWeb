using System;
using System.Linq;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands.Admin.Parking
{
    public class ResizeSegment : ICommand
    {
        public Guid ParkingId { get; set; }
        public Guid SegmentId { get; set; }
        public int AmountPlaces { get; set; }
    }

    public class ResizeSegmentCommandHandler : CommandHandler<ResizeSegment>
    {
        public override void Execute(ResizeSegment command)
        {
            var parking = Please.Give(new ParkingAggregate(command.ParkingId));
            var segment = parking.Segments.First(s => s.Id == command.SegmentId);
            segment.Resize(command.AmountPlaces);
            Data.SaveChanges();
        }
    }
}