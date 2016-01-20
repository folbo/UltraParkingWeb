using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ultra.Core.Domain.ViewModels;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries.Owner
{
    public class OwnerTransactions : IQuery<IEnumerable<PaymentVM>>
    {
        public OwnerTransactions(Guid ownerId)
        {
            OwnerId = ownerId;
        }

        public Guid OwnerId { get; set; }
    }

    public class OwnerTransactionsQueryPerformer : QueryPerformer<OwnerTransactions, IEnumerable<PaymentVM>>
    {
        public override IEnumerable<PaymentVM> Perform(OwnerTransactions query)
        {
            var parkingIds = Data.Parkings.Where(parking => parking.OwnerId == query.OwnerId).Select(parking => parking.Id).ToList();

            return Data.DriverPayments
                .Include(p => p.DriverId)
                .Where(payment => parkingIds.Contains(payment.ParkingId))
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
                .OrderBy(vm => vm.StartTime);
        }
    }
}