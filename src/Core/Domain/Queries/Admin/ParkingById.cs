using System;
using System.Linq;
using AutoMapper;
using Ultra.Core.Domain.ViewModels;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries.Admin
{
    public class ParkingById : IQuery<ParkingVM>
    {
        public Guid Id { get; set; }
    }

    public class ParkingByIdQueryPerformer : QueryPerformer<ParkingById, ParkingVM>
    {
        public override ParkingVM Perform(ParkingById query)
        {
            var parking = Data.Parkings.First(vm => vm.Id == query.Id);
            return Mapper.Map<ParkingVM>(parking);
        }
    }
}