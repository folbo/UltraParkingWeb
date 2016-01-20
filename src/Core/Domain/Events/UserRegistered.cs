using System;
using Ultra.Core.Infrastructure.Events;

namespace Ultra.Core.Domain.Events
{
    public class UserRegistered : IEvent
    {
        public UserRegistered(Guid userId, string carId, string firstName, string lastName)
        {
            EventId = Guid.NewGuid();
            UserId = userId;
            CarId = carId;
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid UserId { get; }
        public string CarId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public Guid EventId { get; }
    }
}