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
    public class ResizeParking : ICommand
    {
        public ResizeParking(Guid parkingId, int amount)
        {
            ParkingId = parkingId;
            Amount = amount;
        }

        public Guid ParkingId;
        public int Amount;
    }

    public class ResizeParkingCommandHandler : CommandHandler<ResizeParking>
    {
        public override void Execute(ResizeParking command)
        {
            var parking = Data.Parkings.Single(x => x.Id == command.ParkingId);
            parking.TotalPlaces = command.Amount;
            
            Data.SaveChanges();
        }
    }
}
