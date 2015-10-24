namespace Ultra.Core.Infrastructure.Commands
{
    public interface ICommandBus
    {
        CommandResult Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }

    public class CommandBus : ICommandBus
    {
        public CommandResult Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            IoC.Resolve<ICommandHandler<TCommand>>().Execute(command);
            return CommandResult.Success();
        }
    }
}