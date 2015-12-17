using System;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands
{
    public class CreateParking : ICommand
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }

        public CreateParking(string name)
        {
            Name = name;
        }
    }

    public class CreateParkingCommandHandler : CommandHandler<CreateParking>
    {
        public override void Execute(CreateParking command)
        {
            var parking = new Parking()
            {
                Name = command.Name,
            };

            Data.Parkings.Add(parking);

            Data.SaveChanges();
        }
    }
}
