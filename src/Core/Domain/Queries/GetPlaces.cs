using System;
using System.Collections.Generic;
using System.Linq;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries
{
    public class PlacesForParking : IQuery<IEnumerable<Place>>
    {
        public PlacesForParking(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public class PlacesForParkingQueryPerformer : QueryPerformer<PlacesForParking, IEnumerable<Place>>
    {
        public override IEnumerable<Place> Perform(PlacesForParking query)
        {
            return Data.Parkings.SingleOrDefault(x => x.Id == query.Id).Places;
        }
    }
}
