using System;
using System.Linq;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands.Admin.Parking
{
    public class ChangeParkingOwner : ICommand
    {
        public Guid ParkingId { get; set; }
        public string NewOwnerName { get; set; }
    }

    public class ChangeParkingOwnerCommandHandler : CommandHandler<ChangeParkingOwner>
    {
        public override void Execute(ChangeParkingOwner command)
        {
            var parking = Please.Give(new ParkingAggregate(command.ParkingId));
            var owner =
                Data.Owners.First(o => o.Name.Equals(command.NewOwnerName, StringComparison.InvariantCultureIgnoreCase));
            parking.SetOwner(owner.Id, owner.Name);
            Data.SaveChanges();
        }
    }
}