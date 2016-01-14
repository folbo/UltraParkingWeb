using System;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands.Admin.Parking
{
    public class AddSegment : ICommand
    {
        public Guid ParkingId { get; set; }
        public string Name { get; set; }
        public int AmountPlaces { get; set; }
        public Guid NewId { get; set; }
    }

    public class AddSegmentCommandHandler : CommandHandler<AddSegment>
    {
        public override void Execute(AddSegment command)
        {
            var parking = Please.Give(new ParkingAggregate(command.ParkingId));
            parking.AddSegment(command.Name,command.AmountPlaces,command.NewId);
            Data.SaveChanges();
        }
    }
}
