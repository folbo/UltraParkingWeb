using System;
using AutoMapper;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Domain.ViewModels;
using Ultra.Core.Infrastructure.Data;

namespace Ultra.Core.Mappings
{
    public class VMMappings
    {
        public static void Register()
        {
            Mapper.CreateMap<Parking, ParkingInfoVM>();

            Mapper.CreateMap<Parking, ParkingVM>()
                .ForMember(dest => dest.Longitude, c => c.ResolveUsing(src => src.Location?.Longitude ?? 21.00997))
                .ForMember(dest => dest.Latitude, c => c.ResolveUsing(src => src.Location?.Latitude ?? 52.22838));

            Mapper.CreateMap<ParkingSegment, ParkingSegmentVM>();
            Mapper.CreateMap<Owner, OwnerVM>();


            //Mapper.CreateMap<Parking, ParkingDTO>();
            //Mapper.CreateMap<source, destination>()
            //    .ForMember(dest => dest.propery, c => c.MapFrom(src => src.anotherProperty))
            //    .ForMember(dest => dest.propery,c => c.ResolveUsing<CustomResolver>().FromMember(src => src.anotherProperty))
        }
    }
}