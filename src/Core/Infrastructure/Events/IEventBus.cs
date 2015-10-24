namespace Ultra.Core.Infrastructure.Events
{
    public interface IEventBus
    {
        void Send<T>(T @event);
    }

    public class EventBus : IEventBus
    {
        public void Send<T>(T @event)
        {
            var handlers = IoC.ResolveAll<IEvent<T>>();
            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}