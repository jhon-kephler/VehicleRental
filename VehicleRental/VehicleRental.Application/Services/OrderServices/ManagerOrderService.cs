using MediatR;
using VehicleRental.Core.Helper;
using VehicleRental.Application.Services.OrderServices.Interfaces;
using VehicleRental.Domain.Entities;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.OrderSchemas.Request;
using VehicleRental.Data.Query.RenterQuery.Interfaces;
using VehicleRental.Data.Query.VehicleQuery.Interfaces;
using VehicleRental.Data.Command.OrderCommand;
using AutoMapper;
using VehicleRental.Core.Schema.OrderSchemas.Response;

namespace VehicleRental.Application.Services.OrderServices
{
    public class ManagerOrderService : IManagerOrderService
    {
        private readonly IMapper _mapper;
        private readonly IGetRenterByIdQuery _getRenterByIdQuery;
        private readonly IGetVehicleByIdQuery _vehicleByIdQuery;
        private readonly ISaveOrderCommand _saveOrderCommand;

        public ManagerOrderService(IMapper mapper, 
            IGetRenterByIdQuery getRenterByIdQuery, 
            IGetVehicleByIdQuery vehicleByIdQuery, 
            ISaveOrderCommand saveOrderCommand)
        {
            _mapper = mapper;
            _getRenterByIdQuery = getRenterByIdQuery;
            _vehicleByIdQuery = vehicleByIdQuery;
            _saveOrderCommand = saveOrderCommand;
        }

        public async Task<Result> NewOrder(NewOrderRequest request)
        {
            var result = new Result();

            var renter = await _getRenterByIdQuery.GetByIdAsync(request.Renter_Id);
            var validateRenter = await ValidateRenter(renter);
            if(!validateRenter.IsSuccess)
                return validateRenter;

            var vehicle = await _vehicleByIdQuery.GetByIdAsync(request.Vehicle_Id);
            var validateVehicle = await ValidateVehicle(vehicle, renter);
            if(!validateVehicle.IsSuccess)
                return validateVehicle;

            try
            {
                var order = new OrderResponse(await PlansValues(request.Rental_Days), "leased", renter.Id, vehicle.Id);
                await _saveOrderCommand.SaveRenterOrder(_mapper.Map<RenterOrder>(order));
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.ValidateResult(ex.Message);
            }

            return result;
        }

        private async Task<decimal> PlansValues(int rental_Days)
        {
            var value = rental_Days switch
            {
                7 => 7 * 30M,
                15 => 15 * 28M,
                30 => 30 * 22M,
                _ => 0
            };
            return value;
        }

        private async Task<Result> ValidateRenter(Renter? renter)
        {
            var result = new Result();
            result.IsSuccess = true;

            if(renter == null)
                result.ValidateResult("Locatário não encontrado");

            if (renter.CNH == null || renter.CNH_Type == null || renter.CNH_Img_Url == null || !renter.CNH_Expiration_Date.HasValue)
                result.ValidateResult("Verifique as informações de CNH");

            if (renter.CNH_Expiration_Date.Value.Date < DateTime.Now.Date)
                result.ValidateResult("Cnh expirada");

            return result;
        }

        private async Task<Result> ValidateVehicle(Vehicle? vehicle, Renter? renter)
        {
            var result = new Result();
            result.IsSuccess = true;

            if (vehicle == null)
                result.ValidateResult("Veiculo não encontrado");

            if(!ValidateTypeCnhAndVehicle(vehicle, renter))
                result.ValidateResult("CNH inválida para este veiculo");

            if(!vehicle.Availability)
                result.ValidateResult("Veiculo indisponivel");

            return result;
        }

        public static bool ValidateTypeCnhAndVehicle(Vehicle? vehicle, Renter renter)
        {
            if (vehicle.Model == "car" && (renter.CNH_Type != "B" || renter.CNH_Type != "AB"))
                return false;


            if (vehicle.Model == "motorcycle" && (renter.CNH_Type != "A" || renter.CNH_Type != "AB"))
                return false;

            return true;
        }
    }
}
