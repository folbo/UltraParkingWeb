using System;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands
{
    public class CreateParkingKnownId : ICommand
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }

        public CreateParkingKnownId(Guid id, string name)
        {
            Name = name;
            Id = id;
        }
    }

    public class CreateParkingKnownIdCommandHandler : CommandHandler<CreateParkingKnownId>
    {
        public override void Execute(CreateParkingKnownId command)
        {
            var parking = new Parking()
            {
                Name = command.Name,
                Id = command.Id
            };

            Data.Parkings.Add(parking);

            Data.SaveChanges();
        }
    }
}
