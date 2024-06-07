﻿using AutoMapper;
using VehicleRental.Core.Entities;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.VehicleSchema.Request;
using VehicleRental.Application.Services.AdminVehicle.Interfaces;
using VehicleRental.Data.Command.VehicleCommand.Interfaces;
using VehicleRental.Core.Schema.PlateSchema.Request;
using VehicleRental.Data.Query.VehicleQuery.Interfaces;
using VehicleRental.Core.Schema.DeleteVehicleSchema.Request;
using static VehicleRental.Data.Command.VehicleCommand.DeleteVehicleCommand;
using VehicleRental.Data.Query.BrandQuery.Interfaces;
using VehicleRental.Application.Helper;

namespace VehicleRental.Application.Services.AdminVehicle
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
                if (vehicle.ValidatePlate())
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

                if (vehicle.Renter_Id.HasValue)
                {

                    var brand = await _getBrandByIdQuery.GetByIdAsync(vehicle.Brand_Id);

                    var validate = await ValidateVehicle(vehicle, brand);
                    if (validate.IsSuccess)
                    {
                        result.ValidateResult("Veiculos cadastrados corretamente não podem ser excluidos");
                        return result;
                    }

                    await _deleteVehicleCommand.DeleteVehicle(_mapper.Map<DeleteVehicleQuery>(request));
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

            if (vehicle.ValidatePlate())
                result.ValidateResult("Placa inválida");

            if (vehicle.Brand_Id != brands.Id || brands == null || vehicle.Brand_Id != null)
                result.ValidateResult("Marca inválida");

            return result;
        }
    }
}