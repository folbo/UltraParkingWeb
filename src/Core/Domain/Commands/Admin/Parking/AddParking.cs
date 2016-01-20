using System;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands.Admin.Parking
{
    public class AddParking : ICommand
    {
        public Guid newId { get; set; }
        public string Name { get; set; }
    }

    public class AddParkingCommandHandler : CommandHandler<AddParking>
    {
        public override void Execute(AddParking command)
        {
            var parking = Entities.Parking.Create(command.Name, command.newId);
            Data.Parkings.Add(parking);
            Data.SaveChanges();
        }
    }
}