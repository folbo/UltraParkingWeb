namespace Ultra.Core.Infrastructure.Events
{
    public interface IEventBus
    {
        void Send<T>(T @event) where T : IEvent;
    }

    public class EventBus : IEventBus
    {
        public void Send<T>(T @event) where T : IEvent
        {
            var handlers = IoC.ResolveAll<IEventHandler<T>>();
            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}