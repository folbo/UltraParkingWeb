namespace Ultra.Core.Infrastructure.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }

    public abstract class EventHandler<T> : Base, IEventHandler<T> where T : IEvent
    {
        public abstract void Handle(T @event);
    }
}