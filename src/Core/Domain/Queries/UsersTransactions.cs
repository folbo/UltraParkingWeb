using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ultra.Core.Domain.Queries.Owner;
using Ultra.Core.Domain.ViewModels;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries
{
    public class UsersTransactions : IQuery<IEnumerable<PaymentVM>>
    {
        public UsersTransactions(Guid driverId)
        {
            DriverId = driverId;
        }

        public Guid DriverId { get; set; }
    }

    public class UsersTransactionsQueryPerformer : QueryPerformer<UsersTransactions, IEnumerable<PaymentVM>>
    {
        public override IEnumerable<PaymentVM> Perform(UsersTransactions query)
        {
            var parkingIds = Data.Parkings.Where(parking => parking.OwnerId == query.DriverId).Select(parking => parking.Id).ToList();

            return Data.DriverPayments
                .Include(p => p.DriverId)
                .Where(payment => payment.DriverId==query.DriverId)
                .Join(Data.Parkings
                    , payment => payment.ParkingId
                    , parking => parking.Id
                    , (payment, parking) => new PaymentVM
                    {
                        DriverName = payment.Driver.FirstName + " " + payment.Driver.LastName,
                        StartTime = payment.StartTime,
                        EndTime = payment.EndTime,
                        Price = payment.Price,
                        ParkingName = parking.Name
                    })
                .OrderByDescending(vm => vm.StartTime);
        }
    }
}