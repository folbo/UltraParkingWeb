using Ultra.Core.Domain.Entities;
using Ultra.Core.Domain.Events;
using Ultra.Core.Infrastructure.Events;

namespace Ultra.Core.Domain.EventHandlers
{
    public class FinalizeRegistration : EventHandler<UserRegistered>
    {
        public override void Handle(UserRegistered @event)
        {
            Data.Drivers.Add(Driver.Create(@event.UserId, @event.CarId, @event.FirstName, @event.LastName));
            Data.SaveChanges();
        }
    }
}