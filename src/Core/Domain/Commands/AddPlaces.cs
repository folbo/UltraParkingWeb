using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands
{
    public class AddPlaces : ICommand
    {
        public AddPlaces(Guid parkingId, int amount, int beginFrom)
        {
            ParkingId = parkingId;
            Amount = amount;
            BeginFrom = beginFrom;
        }

        public Guid ParkingId;
        public int Amount;
        public int BeginFrom;
    }

    public class AddPlacesCommandHandler : CommandHandler<AddPlaces>
    {
        public override void Execute(AddPlaces command)
        {
            for (int i = 0; i < command.Amount; i++)
            {
                var place = new Place()
                {
                    Driver = null,
                    Parking = Data.Parkings.Find(command.ParkingId)
                };

                Data.Places.Add(place);
            }

            Data.SaveChanges();
        }
    }
}
