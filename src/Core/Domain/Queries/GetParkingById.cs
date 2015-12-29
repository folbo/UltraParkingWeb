using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries
{
    public class GetParkingById : IQuery<Parking>
    {
        public Guid Id;

        public GetParkingById(Guid id)
        {
            Id = id;
        }
    }

    public class GetParkingByIdQueryPerformer : QueryPerformer<GetParkingById, Parking>
    {
        public override Parking Perform(GetParkingById query)
        {
            return Data.Parkings.SingleOrDefault(p => p.Id == query.Id);
        }
    }
}
