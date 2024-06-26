using AutoMapper;
using VehicleRental.Application.Services.VehicleServices.Interfaces;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Request;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Response;
using VehicleRental.Domain.Entities;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Application.Services.VehicleServices
{
    public class SearchVehicleService : ISearchVehicleService
    {
        public readonly IMapper _mapper;
        public readonly IRepository<Vehicle> _vehicleRepository;

        public SearchVehicleService(IMapper mapper, 
            IRepository<Vehicle> vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<Result<SearchVehicleResponse>> SearchVehicleById(SearchVehicleByIdRequest request)
        {
            var result = new Result<SearchVehicleResponse>();

            try
            {
                var vehicle = _vehicleRepository.GetById(request.Vehicle_Id);
                if (vehicle == null)
                    result.ValidateResult("Vehicle_Id inválido");
                else
                    result.SetSuccess(_mapper.Map<SearchVehicleResponse>(vehicle));

                return result;
            }
            catch (Exception ex)
            {
                result.ValidateResult(ex.Message);
            }

            return result;
        }

        public async Task<Result<SearchVehicleResponse>> SearchVehicleByPlate(SearchVehicleByPlateRequest request)
        {
            var result = new Result<SearchVehicleResponse>();

            try
            {
                var vehicle = _vehicleRepository.GetByPlate(request.Plate);
                if (vehicle == null)
                    result.ValidateResult("Placa inválida");
                else
                    result.SetSuccess(_mapper.Map<SearchVehicleResponse>(vehicle));

                return result;
            }
            catch (Exception ex)
            {
                result.ValidateResult(ex.Message);
            }

            return result;
        }
    }
}
