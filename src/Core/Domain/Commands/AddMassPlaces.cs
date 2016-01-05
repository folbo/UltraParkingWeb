using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands
{
    public class AddMassPlaces : ICommand
    {
        public Guid ParkingId;
        public string NamePrefix;
        public string NameSuffix;
        public int StartNumber;
        public int Amount;

        public AddMassPlaces(Guid parkingId, string namePrefix, string nameSuffix, int startNumber, int amount)
        {
            ParkingId = parkingId;
            NamePrefix = namePrefix;
            NameSuffix = nameSuffix;
            StartNumber = startNumber;
            Amount = amount;
        }
    }

    public class AddMassPlacesCommandHandler : CommandHandler<AddMassPlaces>
    {
        public override void Execute(AddMassPlaces command)
        {
            int first = command.StartNumber;
            int last = command.StartNumber + command.Amount;
            for (int i = first; i <= last; i++)
            {
                var place = new Place()
                {
                    ParkingId = command.ParkingId,
                    Status = Status.Free,
                    NamePrefix = command.NamePrefix,
                    NameMainPattern = i.ToString().PadLeft(last.ToString().Length, '0'),
                    NameSuffix = command.NameSuffix
                };

                Data.Places.Add(place);
            }

            //zwiększ wartość (cough)kłopotliwych(cough) pól parkingu
            var parking = Data.Parkings.Single(x => x.Id == command.ParkingId);
            parking.TotalPlaces += command.Amount;
            parking.FreePlaces += command.Amount;

            Data.SaveChanges();
        }
    }
}