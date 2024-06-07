using AutoMapper;
using VehicleRental.Core.Entities;
using VehicleRental.Core.Schema.VehicleSchema.Request;
using VehicleRental.Core.Schema.PlateSchema.Request;
using VehicleRental.Core.Schema.DeleteVehicleSchema.Request;
using static VehicleRental.Data.Command.VehicleCommand.DeleteVehicleCommand;
using VehicleRental.Core.Schema.VehicleSchema.Response;

namespace VehicleRental.Application.Mapper
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleRequest, Vehicle>()
                .ForMember(dest => dest.Year_Vehicle, src => src.MapFrom(x => x.Year_Vehicle))
                .ForMember(dest => dest.Model, src => src.MapFrom(x => x.Model))
                .ForMember(dest => dest.Plate, src => src.MapFrom(x => x.Plate));

            CreateMap<PlateRequest, Vehicle>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.VehicleId))
                .ForMember(dest => dest.Plate, src => src.MapFrom(x => x.Plate));

            CreateMap<DeleteVehicleRequest, DeleteVehicleQuery>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.VehicleId));

            CreateMap<Vehicle, SearchVehicleResponse>()
                .ForMember(dest => dest.Vehicle_Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Year_Vehicle, src => src.MapFrom(x => x.Year_Vehicle))
                .ForMember(dest => dest.Brand_Id, src => src.MapFrom(x => x.Brand_Id))
                .ForMember(dest => dest.Renter_Id, src => src.MapFrom(x => x.Renter_Id))
                .ForMember(dest => dest.Plate, src => src.MapFrom(x => x.Plate))
                .ForMember(dest => dest.Model, src => src.MapFrom(x => x.Model));
        }
    }
}
