using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ultra.Core.Domain.DTO;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Domain.ViewModels;

namespace Ultra.Core.Mappings
{
    public class VMMappings
    {
        public static void Register()
        {
            Mapper.CreateMap<Parking, ParkingInfoVM>()
                .ForMember(dest => dest.OwnerName, c => c.UseValue("MR Todo")); // todo 

            Mapper.CreateMap<Parking, ParkingVM>()
                .ForMember(dest => dest.Longitude, c => c.ResolveUsing(src => src.Location?.Longitude ?? 21.00997))
                .ForMember(dest => dest.Latitude, c => c.ResolveUsing(src => src.Location?.Latitude?? 52.22838))
                .ForMember(dest => dest.OwnerName, c => c.UseValue("MR Todo")); // todo 

            Mapper.CreateMap<ParkingSegment, ParkingSegmentVM>();;
                //.ForMember(dest => dest.PlacesCount, c => c.ResolveUsing(src => src.ParkingsPlaces.Count)); // todo 


            //Mapper.CreateMap<Parking, ParkingDTO>();
            //Mapper.CreateMap<source, destination>()
            //    .ForMember(dest => dest.propery, c => c.MapFrom(src => src.anotherProperty))
            //    .ForMember(dest => dest.propery,c => c.ResolveUsing<CustomResolver>().FromMember(src => src.anotherProperty))
        }
    }
}