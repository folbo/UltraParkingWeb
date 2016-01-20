using System;
using Ultra.Core.Domain.Events;
using Ultra.Core.Domain.Queries.Domain;

namespace Ultra.Core.Domain.EventHandlers
{
    public class SettlementReservation : Infrastructure.Events.EventHandler<ParkingPlaceHasBeenReleased>
    {
        public override void Handle(ParkingPlaceHasBeenReleased @event)
        {
            var driver = Please.Give(new DriverAggregate(@event.DriverId));
            var timeSpan = @event.To - @event.From;
            var price = (decimal) (Math.Ceiling(timeSpan.TotalHours)*5);
            driver.AddPayment(@event.From, @event.To, @event.ParkingPlaceId, @event.ParkingId, price);
        }
    }
}