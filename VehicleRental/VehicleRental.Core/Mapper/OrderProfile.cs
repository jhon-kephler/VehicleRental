using AutoMapper;
using VehicleRental.Core.Schema.OrderSchemas.Response;
using VehicleRental.Domain.Entities;

namespace VehicleRental.Core.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderResponse, RenterOrder>()
                .ForMember(dest => dest.Status, src => src.MapFrom(x => x.Status))
                .ForMember(dest => dest.Rental_Value, src => src.MapFrom(x => x.Rental_Value))
                .ForMember(dest => dest.Renter_Id, src => src.MapFrom(x => x.Renter_Id))
                .ForMember(dest => dest.Vehicle_Id, src => src.MapFrom(x => x.Vehicle_Id))
                .ForMember(dest => dest.Created_Date, src => src.MapFrom(x => DateTime.UtcNow));
        }
    }
}
