using System;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands.Admin.Parking
{
    public class DeleteParking : ICommand
    {
        public Guid ParkingId { get; set; }
    }

    public class DeleteParkingCommandHandler : CommandHandler<DeleteParking>
    {
        public override void Execute(DeleteParking command)
        {
            var parking = Data.Parkings.Find(command.ParkingId);
            Data.Parkings.Remove(parking);
            Data.SaveChanges();
        }
    }
}