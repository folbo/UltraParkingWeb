using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Ultra.Core.Domain.DTO;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries.API
{
    public class AllParkings : IQuery<IEnumerable<ParkingDTO>>
    {
    }

    public class GetParkingsQueryPerformer : QueryPerformer<AllParkings, IEnumerable<ParkingDTO>>
    {
        public override IEnumerable<ParkingDTO> Perform(AllParkings query)
        {
            return Data.Parkings
                .ProjectTo<ParkingDTO>()
                .ToList();
        }
    }
}