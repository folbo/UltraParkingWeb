using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Ultra.Core.Domain.ViewModels;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries.Owner
{
    public class OwnerParkings : IQuery<IEnumerable<ParkingInfoVM>>
    {
        public OwnerParkings(Guid ownerId)
        {
            OwnerId = ownerId;
        }

        public Guid OwnerId { get; set; }
    }

    public class OwnerParkingsQueryPerformer : QueryPerformer<OwnerParkings, IEnumerable<ParkingInfoVM>>
    {
        public override IEnumerable<ParkingInfoVM> Perform(OwnerParkings query)
        {
            return Data.Parkings
                .Where(parking => parking.OwnerId==query.OwnerId)
                .ProjectTo<ParkingInfoVM>().ToList();
        }
    }
}