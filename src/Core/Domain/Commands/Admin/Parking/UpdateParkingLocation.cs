using System;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands.Admin.Parking
{
    public class UpdateParkingLocation : ICommand
    {
        public Guid ParkingId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class UpdateParkingLocationCommandHandler : CommandHandler<UpdateParkingLocation>
    {
        public override void Execute(UpdateParkingLocation command)
        {
            var parking = Please.Give(new ParkingAggregate(command.ParkingId));
            parking.UpdateLocation(command.Latitude, command.Longitude);
            Data.SaveChanges();
        }
    }
}