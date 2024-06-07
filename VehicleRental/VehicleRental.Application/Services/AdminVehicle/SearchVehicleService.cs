using AutoMapper;
using VehicleRental.Application.Services.AdminVehicle.Interfaces;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.VehicleSchema.Request;
using VehicleRental.Core.Schema.VehicleSchema.Response;
using VehicleRental.Data.Query.VehicleQuery.Interfaces;

namespace VehicleRental.Application.Services.AdminVehicle
{
    public class SearchVehicleService : ISearchVehicleService
    {
        public readonly IMapper _mapper;
        public readonly IGetVehicleByIdQuery _getVehicleByIdQuery;
        public readonly IGetVehicleByPlateQuery _getVehicleByPlateQuery;

        public SearchVehicleService(IMapper mapper,
            IGetVehicleByIdQuery getVehicleByIdQuery,
            IGetVehicleByPlateQuery getVehicleByPlateQuery)
        {
            _mapper = mapper;
            _getVehicleByIdQuery = getVehicleByIdQuery;
            _getVehicleByPlateQuery = getVehicleByPlateQuery;
        }

        public async Task<Result<SearchVehicleResponse>> SearchVehicleById(SearchVehicleByIdRequest request)
        {
            var result = new Result<SearchVehicleResponse>();

            try
            {
                var vehicle = await _getVehicleByIdQuery.GetByIdAsync(request.Vehicle_Id);
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
                var vehicle = await _getVehicleByPlateQuery.GetByPlateAsync(request.Plate);
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
