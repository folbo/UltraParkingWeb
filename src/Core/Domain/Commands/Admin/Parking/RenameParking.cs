using System;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands.Admin.Parking
{
    public class RenameParking : ICommand
    {
        public Guid ParkingId { get; set; }
        public string NewName { get; set; }
    }

    public class RenameParkingCommandHandler : CommandHandler<RenameParking>
    {
        public override void Execute(RenameParking command)
        {
            var parking = Please.Give(new ParkingAggregate(command.ParkingId));
            parking.Rename(command.NewName);
            Data.SaveChanges();
        }
    }
}