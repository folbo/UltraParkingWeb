using System;
using Ultra.Core.Domain.Events;

namespace Ultra.Core.Domain.EventHandlers
{
    public class SettlementReservation: Infrastructure.Events.EventHandler<ParkingPlaceHasBeenReleased>
    {
        public override void Handle(ParkingPlaceHasBeenReleased @event)
        {
                        
        }
    }
}
