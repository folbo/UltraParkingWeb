using System;
using System.Linq;
using AutoMapper;
using Ultra.Core.Domain.DTO;
using Ultra.Core.Domain.ViewModels;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries
{
    public class UserStatus : IQuery<UserStatusDTO>
    {
        public UserStatus(Guid driverId)
        {
            DriverId = driverId;
        }

        public Guid DriverId { get; set; }
    }

    public class UserStatusQueryPerformer : QueryPerformer<UserStatus, UserStatusDTO>
    {
        public override UserStatusDTO Perform(UserStatus query)
        {
            var driverVM = Mapper.Map<UserStatusDTO>(Data.Drivers.Find(query.DriverId));
            driverVM.ReserverParkingId =
                Data.ParkingsPlaces.FirstOrDefault(place => place.DriverId == query.DriverId)?.ParkingId;
            return driverVM;
        }
    }
}