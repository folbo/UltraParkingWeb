using System;
using AutoMapper;
using Ultra.Core.Domain.DTO;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands.Client
{
    public class ChangeCarId : ICommand
    {
        public string CarId{ get; set; }
        public Guid UserId { get; set; }
    }

    public class ChangeCarIdCommandHandler : CommandHandler<ChangeCarId>
    {
        public override void Execute(ChangeCarId command)
        {
            var driver = Data.Drivers.Find(command.UserId);
            driver.UpdateCarId(command.CarId);
            Data.SaveChanges();
        }
    }
}