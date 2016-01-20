using System;
using AutoMapper;
using Ultra.Core.Domain.DTO;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands.Client
{
    public class ChangeLastName : ICommand
    {
        public string Lastname{ get; set; }
        public Guid UserId { get; set; }
    }

    public class ChangeLastNameCommandHandler : CommandHandler<ChangeLastName>
    {
        public override void Execute(ChangeLastName command)
        {
            var driver = Data.Drivers.Find(command.UserId);
            driver.UpdateLastName(command.Lastname);
            Data.SaveChanges();
        }
    }
}