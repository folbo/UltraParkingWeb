using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ultra.Core.Domain.ViewModels;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries.Admin
{
    public class AllTransactions : IQuery<IEnumerable<PaymentVM>>
    {
    }

    public class AllTransactionsQueryPerformer : QueryPerformer<AllTransactions, IEnumerable<PaymentVM>>
    {
        public override IEnumerable<PaymentVM> Perform(AllTransactions query)
        {
            return Data.DriverPayments
                .Include(p => p.DriverId)
                .Join(Data.Parkings
                    , payment => payment.ParkingId
                    , parking => parking.Id
                    , (payment, parking) => new PaymentVM()
                    {
                        DriverName = payment.Driver.FirstName + " " + payment.Driver.LastName,
                        StartTime = payment.StartTime,
                        EndTime = payment.EndTime,
                        Price = payment.Price,
                        ParkingName = parking.Name,
                    })
                .OrderBy(vm => vm.StartTime);
        }
    }
}