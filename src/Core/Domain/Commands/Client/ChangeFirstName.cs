using System;
using AutoMapper;
using Ultra.Core.Domain.DTO;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands.Client
{
    public class ChangeFirstName : ICommand
    {
        public string Firstname{ get; set; }
        public Guid UserId { get; set; }
    }

    public class ChangeFirstNameCommandHandler : CommandHandler<ChangeFirstName>
    {
        public override void Execute(ChangeFirstName command)
        {
            var driver = Data.Drivers.Find(command.UserId);
            driver.UpdateFirstName(command.Firstname);
            Data.SaveChanges();
        }
    }
}