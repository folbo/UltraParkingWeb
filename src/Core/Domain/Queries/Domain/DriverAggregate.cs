using System;
using System.Data.Entity;
using System.Linq;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries.Domain
{
    public class DriverAggregate : IQuery<Driver>
    {
        public DriverAggregate(Guid driverId)
        {
            DriverId = driverId;
        }

        public Guid DriverId { get; set; }
    }

    public class DriverAggregateQueryPerformer : QueryPerformer<DriverAggregate, Driver>
    {
        public override Driver Perform(DriverAggregate query)
        {
            return Data.Drivers
                .Include(p=>p.Payments)
                .First(x => x.Id == query.DriverId);
        }
    }
}
