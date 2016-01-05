using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Ultra.Core.Domain.DTO;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries.API
{
    public class GetParkingsInArea : IQuery<IEnumerable<ParkingDTO>>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
    }

    public class GetParkingsInAreaQueryPerformer : QueryPerformer<GetParkingsInArea, IEnumerable<ParkingDTO>>
    {
        public override IEnumerable<ParkingDTO> Perform(GetParkingsInArea query)
        {
            var userLocation = DbGeography.FromText($"Point({query.Latitude.ToString(CultureInfo.InvariantCulture)} {query.Longitude.ToString(CultureInfo.InvariantCulture)})");
            return Data.Parkings
                .Where(parking => userLocation.Distance(parking.Location) < query.Radius)
                .ProjectTo<ParkingDTO>()
                .ToList();
        }
    }
}