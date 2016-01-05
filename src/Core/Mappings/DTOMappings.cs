using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ultra.Core.Domain.DTO;
using Ultra.Core.Domain.Entities;

namespace Ultra.Core.Mappings
{
    public class DTOMappings
    {
        public static void Register()
        {
            Mapper.CreateMap<Parking, ParkingDTO>();
            //Mapper.CreateMap<source, destination>()
            //    .ForMember(dest => dest.propery, c => c.MapFrom(src => src.anotherProperty))
            //    .ForMember(dest => dest.propery,c => c.ResolveUsing<CustomResolver>().FromMember(src => src.anotherProperty))
        }

    }
}
