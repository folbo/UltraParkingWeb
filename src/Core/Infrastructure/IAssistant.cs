using Ultra.Core.Infrastructure.Commands;
using Ultra.Core.Infrastructure.Events;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Infrastructure
{
    public interface IAssistant
    {
        CommandResult Do<TCommand>(TCommand command) where TCommand : ICommand;
        void Tell<TEvent>(TEvent @event) where TEvent : IEvent;
        TResult Give<TResult>(IQuery<TResult> query);
        bool Check(IQuery<bool> query);
    }

    public class Assistant : IAssistant
    {
        private readonly ICommandBus _commandBus;
        private readonly IEventBus _eventBus;
        private readonly IQueryBus _queryBus;

        public Assistant(IEventBus eventBus, ICommandBus commandBus, IQueryBus queryBus)
        {
            _eventBus = eventBus;
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        public TResult Give<TResult>(IQuery<TResult> query)
        {
            return _queryBus.Perform(query);
        }

        public bool Check(IQuery<bool> check)
        {
            return _queryBus.Check(check);
        }

        CommandResult IAssistant.Do<TCommand>(TCommand command)
        {
            return _commandBus.Execute(command);
        }

        public void Tell<TEvent>(TEvent @event) where TEvent : IEvent
        {
            _eventBus.Send(@event);
        }
    }
}