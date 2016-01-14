using System;
using System.Linq;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands.Admin.Parking
{
    public class RemoveSegment : ICommand
    {
        public Guid ParkingId { get; set; }
        public Guid SegmentId { get; set; }
    }

    public class RemoveSegmentCommandHandler : CommandHandler<RemoveSegment>
    {
        public override void Execute(RemoveSegment command)
        {
            var parking = Please.Give(new ParkingAggregate(command.ParkingId));
            parking.RemoveSegment(command.SegmentId);
            Data.SaveChanges();
        }
    }
}
