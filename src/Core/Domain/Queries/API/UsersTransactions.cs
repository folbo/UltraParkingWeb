
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ultra.Core.Domain.DTO;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries.API
{
    public class UsersTransactions : IQuery<IEnumerable<PaymentDTO>>
    {
        public UsersTransactions(Guid driverId)
        {
            DriverId = driverId;
        }

        public Guid DriverId { get; set; }
    }

    public class UsersTransactionsQueryPerformer : QueryPerformer<UsersTransactions, IEnumerable<PaymentDTO>>
    {
        public override IEnumerable<PaymentDTO> Perform(UsersTransactions query)
        {
            return Data.DriverPayments
                .Include(p => p.DriverId)
                .Where(payment => payment.DriverId==query.DriverId)
                .Join(Data.Parkings
                    , payment => payment.ParkingId
                    , parking => parking.Id
                    , (payment, parking) => new PaymentDTO
                    {
                        StartTime = payment.StartTime,
                        EndTime = payment.EndTime,
                        Price = payment.Price,
                        ParkingName = parking.Name
                    })
                .OrderByDescending(vm => vm.StartTime);
        }
    }
}