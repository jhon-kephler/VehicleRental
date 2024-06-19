using AutoMapper;
using VehicleRental.Domain.Entities;
using VehicleRental.Core.Schema;
using VehicleRental.Application.Services.VehicleServices.Interfaces;
using VehicleRental.Data.Command.VehicleCommand.Interfaces;
using VehicleRental.Data.Query.VehicleQuery.Interfaces;
using VehicleRental.Data.Query.BrandQuery.Interfaces;
using VehicleRental.Core.Helper;
using VehicleRental.Core.Schema.VehicleSchemas.PlateSchema.Request;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Request;
using VehicleRental.Core.Schema.VehicleSchemas.DeleteVehicleSchema.Request;

namespace VehicleRental.Application.Services.VehicleServices
{
    public class ManageVehicleService : IManageVehicleService
    {
        public readonly IMapper _mapper;
        public readonly ISaveVehicleCommand _saveVehicleCommand;
        public readonly IUpdateVehicleCommand _updateVehicleCommand;
        public readonly IDeleteVehicleCommand _deleteVehicleCommand;
        public readonly IGetVehicleByIdQuery _getVehicleByIdQuery;
        public readonly IGetBrandByNameQuery _getBrandByNameQuery;
        public readonly IGetBrandByIdQuery _getBrandByIdQuery;

        public ManageVehicleService(IMapper mapper,
            ISaveVehicleCommand saveVehicleCommand,
            IUpdateVehicleCommand updateVehicleCommand,
            IDeleteVehicleCommand deleteVehicleCommand,
            IGetVehicleByIdQuery getVehicleByIdQuery,
            IGetBrandByNameQuery getBrandByNameQuery,
            IGetBrandByIdQuery getBrandByIdQuery)
        {
            _mapper = mapper;
            _saveVehicleCommand = saveVehicleCommand;
            _updateVehicleCommand = updateVehicleCommand;
            _deleteVehicleCommand = deleteVehicleCommand;
            _getVehicleByIdQuery = getVehicleByIdQuery;
            _getBrandByNameQuery = getBrandByNameQuery;
            _getBrandByIdQuery = getBrandByIdQuery;
        }

        public async Task<Result> CreateNewVehicle(VehicleRequest request)
        {
            var result = new Result();
            try
            {
                var formattedBrandName = BrandHelper.FormatName(request.Brand);
                var brand = await _getBrandByNameQuery.GetByNameAsync(formattedBrandName);

                var vehicle = _mapper.Map<Vehicle>(request);
                vehicle.Brand_Id = brand.Id;
                vehicle.Model = BrandHelper.FormatName(vehicle.Model);

                var validate = await ValidateVehicle(vehicle, brand);
                if (!validate.IsSuccess)
                    return validate;

                await _saveVehicleCommand.SaveVehicle(vehicle);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.ValidateResult(ex.Message);
            }
            return result;
        }

        public async Task<Result> UpdatePlate(PlateRequest request)
        {
            var result = new Result();
            try
            {
                var vehicle = _mapper.Map<Vehicle>(request);
                if (!vehicle.ValidatePlate())
                    result.ValidateResult("Placa inválida");

                await _updateVehicleCommand.UpdateVehicle(vehicle);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.ValidateResult(ex.Message);
            }
            return result;
        }

        public async Task<Result> DeleteVehicle(DeleteVehicleRequest request)
        {
            var result = new Result();
            try
            {
                var vehicle = await _getVehicleByIdQuery.GetByIdAsync(request.VehicleId);

                if (!vehicle.Availability)
                {
                    var brand = await _getBrandByIdQuery.GetByIdAsync(vehicle.Brand_Id);

                    var validate = await ValidateVehicle(vehicle, brand);
                    if (validate.IsSuccess)
                    {
                        result.ValidateResult("Veiculos cadastrados corretamente não podem ser excluidos");
                        return result;
                    }

                    await _deleteVehicleCommand.DeleteVehicle(request.VehicleId);
                    result.IsSuccess = true;
                }
                else
                    result.ValidateResult("Veiculos alugados não podem ser excluidos");
            }
            catch (Exception ex)
            {
                result.ValidateResult(ex.Message);
            }
            return result;
        }

        private async Task<Result> ValidateVehicle(Vehicle vehicle, Brands brands)
        {
            var result = new Result();

            if (!vehicle.ValidatePlate())
                result.ValidateResult("Placa inválida");

            if (vehicle.Brand_Id != brands.Id || brands == null || vehicle.Brand_Id == null)
                result.ValidateResult("Marca inválida");

            return result;
        }
    }
}