using System;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands
{
    public class EditProject : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class EditProjectCommandHandler : CommandHandler<EditProject>
    {
        public override void Execute(EditProject command)
        {
            var project = Data.Projects.Find(command.Id);
            project.Name = command.Name;
            project.Description= command.Description;

            Data.SaveChanges();
        }
    }
}
