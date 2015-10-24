namespace Ultra.Core.Infrastructure.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }

    public abstract class CommandHandler<TCommand> : Base, ICommandHandler<TCommand> where TCommand : ICommand
    {
        public abstract void Execute(TCommand command);
    }
}