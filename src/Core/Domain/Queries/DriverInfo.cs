using System;
using System.Linq;
using AutoMapper;
using Ultra.Core.Domain.ViewModels;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries
{
    public class DriverInfo : IQuery<DriverVM>
    {
        public DriverInfo(Guid driverId)
        {
            DriverId = driverId;
        }

        public Guid DriverId { get; set; }
    }

    public class DriverInfoQueryPerformer : QueryPerformer<DriverInfo, DriverVM>
    {
        public override DriverVM Perform(DriverInfo query)
        {
            return Mapper.Map<DriverVM>(Data.Drivers.Find(query.DriverId));
        }
    }
}