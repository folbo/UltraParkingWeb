using System;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries
{
    public class UserHaveEnoughMoneyToBook : IQuery<bool>
    {
        public UserHaveEnoughMoneyToBook(Guid driverId)
        {
            DriverId = driverId;
        }

        public Guid DriverId { get; set; }
    }

    public class UserHaveEnoughMoneyToBookQueryPerformer : QueryPerformer<UserHaveEnoughMoneyToBook, bool>
    {
        public override bool Perform(UserHaveEnoughMoneyToBook query)
        {
            var driver = Data.Drivers.Find(query.DriverId);
            return driver.Currency >= (decimal) 20.0;
        }
    }
}