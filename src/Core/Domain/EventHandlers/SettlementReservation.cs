using System.Linq;
using Ultra.Core.Domain.Events;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Domain.Queries.Domain;
using Ultra.Core.Infrastructure.Events;

namespace Ultra.Core.Domain.EventHandlers
{
    public class SettlementReservation : EventHandler<ParkingPlaceHasBeenReleased>
    {
        public override void Handle(ParkingPlaceHasBeenReleased @event)
        {
            var driver = Please.Give(new DriverAggregate(@event.DriverId));
            var timeSpan = @event.To - @event.From;
            var price = (decimal) (timeSpan.TotalHours*5);
            driver.AddPayment(@event.From, @event.To, @event.ParkingPlaceId, @event.ParkingId, price);
        }
    }
}