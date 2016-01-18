using System;
using System.Collections.Generic;
using Ultra.Core.Infrastructure.Events;

namespace Ultra.Core.Infrastructure
{
    internal static class DomainEvents
    {
        public static void Tell<TEvent>(TEvent @event) where TEvent : IEvent
        {
            IoC.Resolve<IEventBus>().Send(@event);
        }
    }
}