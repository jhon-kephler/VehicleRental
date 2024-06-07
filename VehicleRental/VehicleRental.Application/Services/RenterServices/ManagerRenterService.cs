using AutoMapper;
using VehicleRental.Application.Helper;
using VehicleRental.Application.Services.RenterServices.Interfaces;
using VehicleRental.Core.Entities;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request;
using VehicleRental.Data.Command.RenterCommand.Interfaces;

namespace VehicleRental.Application.Services.RenterServices
{
    public class ManagerRenterService : IManagerRenterService
    {
        public readonly IMapper _mapper;
        public readonly ISaveRenterCommand _saveRenterCommand;

        public ManagerRenterService(IMapper mapper, ISaveRenterCommand saveRenterCommand)
        {
            _mapper = mapper;
            _saveRenterCommand = saveRenterCommand;
        }

        public async Task<Result> CreateRenter(RegisterRenterRequest request)
        {
            var result = new Result();

            var validateRegiste = await ValidateRegister(request);
            if (!validateRegiste.IsSuccess)
                return validateRegiste;

            try
            {
                await _saveRenterCommand.SaveRenter(_mapper.Map<Renter>(request));
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.ValidateResult(ex.Message);
            }

            return result;
        } 

        private async Task<Result> ValidateRegister(RegisterRenterRequest request)
        {
            var result = new Result();
            result.IsSuccess = true;

            var cnh = CnhHelper.ValidateCnh(request.CNH);
            if (!cnh)
                result.ValidateResult("CNH inválida");

            if((DateTime.Now.Year - request.Birth_Date.Year) < 18 && (DateTime.Now.Year - request.Birth_Date.Year) > 100)
                result.ValidateResult("Idade inválida");

            if(!DocumentHelper.ValidateDocument(request.Document))
                result.ValidateResult("Documento inválido");

            return result;
        }
    }
}
