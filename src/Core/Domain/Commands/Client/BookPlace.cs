using System;
using AutoMapper;
using Ultra.Core.Domain.DTO;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Infrastructure.Commands;

namespace Ultra.Core.Domain.Commands.Client
{
    public class BookPlace : ICommand
    {
        public Guid ParkingId { get; set; }
        public ParkingPlaceDTO ReturnValue { get; set; }
    }

    public class BookPlaceCommandHandler : CommandHandler<BookPlace>
    {
        public override void Execute(BookPlace command)
        {
            var parking = Please.Give(new ParkingAggregate(command.ParkingId));
            var bookedPlace = parking.BookPlace();
            command.ReturnValue = Mapper.Map<ParkingPlaceDTO>(bookedPlace);
            Data.SaveChanges();
        }
    }
}