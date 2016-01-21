using System;
using System.Linq;
using AutoMapper;
using Ultra.Core.Domain.ViewModels;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries.Owner
{
    public class ParkingWithPlacesById : IQuery<ParkingWithPlacesVM>
    {
        public Guid Id { get; set; }
    }

    public class ParkingWithPlacesByIdQueryPerformer : QueryPerformer<ParkingWithPlacesById, ParkingWithPlacesVM>
    {
        public override ParkingWithPlacesVM Perform(ParkingWithPlacesById query)
        {
            var parking = Data.Parkings.First(vm => vm.Id == query.Id);
            return Mapper.Map<ParkingWithPlacesVM>(parking);
        }
    }
}