using System;
using System.Linq;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries
{
    public class UserHaveActiveBooking : IQuery<bool>
    {
        public UserHaveActiveBooking(Guid driverId)
        {
            DriverId = driverId;
        }

        public Guid DriverId { get; set; }
    }

    public class UserHaveActiveBookingQueryPerformer : QueryPerformer<UserHaveActiveBooking, bool>
    {
        public override bool Perform(UserHaveActiveBooking query)
        {
            return Data.ParkingsPlaces
                .Any(place => place.DriverId == query.DriverId);
        }
    }
}