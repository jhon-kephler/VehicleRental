using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Core.Entities;
using VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request;
using VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Response;

namespace VehicleRental.Application.Mapper
{
    public class RenterProfile : Profile
    {
        public RenterProfile()
        {
            CreateMap<RegisterRenterRequest, Renter>()
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dest => dest.Document, src => src.MapFrom(x => x.Document))
                .ForMember(dest => dest.Birth_Date, src => src.MapFrom(x => x.Birth_Date));

            CreateMap<InsertRentalCNHRequest, Renter>()
                .ForMember(dest => dest.CNH, src => src.MapFrom(x => x.Cnh))
                .ForMember(dest => dest.CNH_Img_Url, src => src.MapFrom(x => x.Cnh_Img_Url))
                .ForMember(dest => dest.CNH_Type, src => src.MapFrom(x => x.Cnh_Type))
                .ForMember(dest => dest.CNH_Type, src => src.MapFrom(x => x.Expiration_Date));

            CreateMap<Renter, SearchRentalResponse>()
                .ForMember(dest => dest.Rental_Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dest => dest.Document, src => src.MapFrom(x => x.Document))
                .ForMember(dest => dest.Birth_Date, src => src.MapFrom(x => x.Birth_Date))
                .ForMember(dest => dest.Cnh, src => src.MapFrom(x => x.CNH))
                .ForMember(dest => dest.Cnh_Img_Url, src => src.MapFrom(x => x.CNH_Img_Url))
                .ForMember(dest => dest.Cnh_Type, src => src.MapFrom(x => x.CNH_Type))
                .ForMember(dest => dest.Cnh_Expiration_Date, src => src.MapFrom(x => x.CNH_Expiration_Date));
        }
    }
}
