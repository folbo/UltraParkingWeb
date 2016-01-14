using System;
using System.Linq;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands.Admin.Parking
{
    public class RenameSegment : ICommand
    {
        public Guid ParkingId { get; set; }
        public Guid SegmentId { get; set; }
        public string NewName { get; set; }
    }

    public class RenameSegmentCommandHandler : CommandHandler<RenameSegment>
    {
        public override void Execute(RenameSegment command)
        {
            var parking = Please.Give(new ParkingAggregate(command.ParkingId));
            var segment = parking.Segments.First(s => s.Id==command.SegmentId);
            segment.Rename(command.NewName);
            Data.SaveChanges();
        }
    }
}
