using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Core.Entities;
using VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request;

namespace VehicleRental.Application.Mapper
{
    public class RenterProfile : Profile
    {
        public RenterProfile()
        {
            CreateMap<RegisterRenterRequest, Renter>()
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dest => dest.Document, src => src.MapFrom(x => x.Document))
                .ForMember(dest => dest.Birth_Date, src => src.MapFrom(x => x.Birth_Date))
                .ForMember(dest => dest.CNH, src => src.MapFrom(x => x.CNH))
                .ForMember(dest => dest.CNH_Img, src => src.MapFrom(x => x.CNH_Img))
                .ForMember(dest => dest.CNH_Type, src => src.MapFrom(x => x.CNH_Type));
        }
    }
}
