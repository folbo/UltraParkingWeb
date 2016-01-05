using System;
using System.Linq;
using AutoMapper;
using Ultra.Core.Domain.DTO;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries.API
{
    public class GetParkingById : IQuery<ParkingDTO>
    {
        public Guid Id;

        public GetParkingById(Guid id)
        {
            Id = id;
        }
    }

    public class GetParkingByIdQueryPerformer : QueryPerformer<GetParkingById, ParkingDTO>
    {
        public override ParkingDTO Perform(GetParkingById query)
        {
            var parking = Data.Parkings.FirstOrDefault(p => p.Id == query.Id);

            return Mapper.Map<ParkingDTO>(parking);
        }
    }
}