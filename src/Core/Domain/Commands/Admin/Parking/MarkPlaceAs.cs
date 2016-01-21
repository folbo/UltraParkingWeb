using System;
using System.Linq;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands.Admin.Parking
{
    public class MarkPlaceAs : ICommand
    {
        public Guid Id { get; set; }
        public Guid ParkingId { get; set; }
        public string Status { get; set; }
    }

    public class MarkPlaceAsCommandHandler : CommandHandler<MarkPlaceAs>
    {
        public override void Execute(MarkPlaceAs command)
        {
            Status empType = (Status)Enum.Parse(typeof(Status), command.Status, true);
            var parking = Please.Give(new ParkingAggregate(command.ParkingId));
            var parkingPlace = parking.Places.First(place => place.Id==command.Id);

            switch (empType)
            {
                case Status.Free:
                    parkingPlace.MarkAsFree();
                    break;
                case Status.Reserved:
                    parkingPlace.MarkAsReserved();
                    break;
                case Status.Busy:
                    parkingPlace.MarkAsBusy();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Data.SaveChanges();
        }
    }
}