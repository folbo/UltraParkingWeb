using System;

namespace Ultra.Core.Infrastructure.Events
{
    public interface IEvent
    {
        Guid EventId { get; }
    }
}