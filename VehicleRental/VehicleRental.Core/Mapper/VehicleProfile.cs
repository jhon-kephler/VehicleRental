using AutoMapper;
using VehicleRental.Domain.Entities;
using VehicleRental.Core.Schema.VehicleSchemas.PlateSchema.Request;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Request;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Response;

namespace VehicleRental.Core.Mapper
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleRequest, Vehicle>()
                .ForMember(dest => dest.Year, src => src.MapFrom(x => x.Year_Vehicle))
                .ForMember(dest => dest.Model, src => src.MapFrom(x => x.Model))
                .ForMember(dest => dest.Plate, src => src.MapFrom(x => x.Plate))
                .ForMember(dest => dest.Availability, src => src.MapFrom(x => x.Availability));

            CreateMap<PlateRequest, Vehicle>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.VehicleId))
                .ForMember(dest => dest.Plate, src => src.MapFrom(x => x.Plate));

            CreateMap<Vehicle, SearchVehicleResponse>()
                .ForMember(dest => dest.Vehicle_Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Year_Vehicle, src => src.MapFrom(x => x.Year))
                .ForMember(dest => dest.Brand_Id, src => src.MapFrom(x => x.Brand_Id))
                .ForMember(dest => dest.Plate, src => src.MapFrom(x => x.Plate))
                .ForMember(dest => dest.Model, src => src.MapFrom(x => x.Model));
        }
    }
}
