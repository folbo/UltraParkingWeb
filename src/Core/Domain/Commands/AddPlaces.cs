using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands
{
    public class AddPlaces : ICommand
    {
        public AddPlaces(Guid parkingId, int amount, string namingPattern)
        {
            ParkingId = parkingId;
            Amount = amount;
            NamingPattern = namingPattern;
        }

        public Guid ParkingId;
        public int Amount;
        public string NamingPattern;
    }

    public class AddPlacesCommandHandler : CommandHandler<AddPlaces>
    {
        public override void Execute(AddPlaces command)
        {
            var parking = Data.Parkings.Single(x => x.Id == command.ParkingId);
            parking.TotalPlaces = command.Amount;
            
            Data.SaveChanges();
        }
    }
}
