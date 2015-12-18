using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries
{
    public class AllParkings : IQuery<IEnumerable<Parking>>
    {}

    public class GetParkingsQueryPerformer : QueryPerformer<AllParkings, IEnumerable<Parking>>
    {
        public override IEnumerable<Parking> Perform(AllParkings query)
        {
            return Data.Parkings.ToList();
        }
    }
}