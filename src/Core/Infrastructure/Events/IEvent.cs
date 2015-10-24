namespace Ultra.Core.Infrastructure.Events
{
    public interface IEvent<in TEvent>
    {
        void Handle(TEvent @event);
    }

    public abstract class EventHandler<T> : Base, IEvent<T>
    {
        public abstract void Handle(T @event);
    }
}