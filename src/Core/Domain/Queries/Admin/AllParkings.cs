using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Ultra.Core.Domain.ViewModels;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries.Admin
{
    public class AllParkings : IQuery<IEnumerable<ParkingInfoVM>>
    {
    }

    public class GetParkingsQueryPerformer : QueryPerformer<AllParkings, IEnumerable<ParkingInfoVM>>
    {
        public override IEnumerable<ParkingInfoVM> Perform(AllParkings query)
        {
            return Data.Parkings.ProjectTo<ParkingInfoVM>().ToList();
        }
    }
}