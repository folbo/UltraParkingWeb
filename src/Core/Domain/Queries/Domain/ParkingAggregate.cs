using System;
using System.Data.Entity;
using System.Linq;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries
{
    public class ParkingAggregate : IQuery<Parking>
    {
        public ParkingAggregate(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public class ParkingAggregateQueryPerformer : QueryPerformer<ParkingAggregate, Parking>
    {
        public override Parking Perform(ParkingAggregate query)
        {
            return Data.Parkings
                .Include(p=>p.Segments)
                .Include(p=>p.Segments.Select(s=>s.Places))
                .First(x => x.Id == query.Id);
        }
    }
}
