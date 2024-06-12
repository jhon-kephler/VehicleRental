using AutoMapper;
using VehicleRental.Application.Helper;
using VehicleRental.Application.Services.RenterServices.Interfaces;
using VehicleRental.Core.Entities;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request;
using VehicleRental.Data.Command.RenterCommand.Interfaces;
using VehicleRental.Data.Query.RenterQuery.Interfaces;

namespace VehicleRental.Application.Services.RenterServices
{
    public class ManagerRenterService : IManagerRenterService
    {
        public readonly IMapper _mapper;
        public readonly ISaveRenterCommand _saveRenterCommand;
        public readonly IGetRenterByIdQuery _getRenterByIdQuery;
        public readonly ISaveRenterCnhCommand _saveRenterCnhCommand;

        public ManagerRenterService(IMapper mapper, 
            ISaveRenterCommand saveRenterCommand, 
            IGetRenterByIdQuery getRenterByIdQuery, 
            ISaveRenterCnhCommand saveRenterCnhCommand)
        {
            _mapper = mapper;
            _saveRenterCommand = saveRenterCommand;
            _getRenterByIdQuery = getRenterByIdQuery;
            _saveRenterCnhCommand = saveRenterCnhCommand;
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

        public async Task<Result> InsertCnh(InsertRentalCNHRequest request)
        {
            var result = new Result();

            var validateCnh = await ValidateCnh(request);
            if (!validateCnh.IsSuccess)
                return validateCnh;

            var renter = await _getRenterByIdQuery.GetByIdAsync(request.Rental_Id);
            if(renter == null)
            {
                result.ValidateResult("Renter_Id inválido");
                return result;
            }

            try
            {
                renter = _mapper.Map<Renter>(request);
                await _saveRenterCnhCommand.SaveCnhRenter(renter);
            }
            catch(Exception ex)
            {
                result.ValidateResult(ex.Message);
            }

            return result;
        }

        private async Task<Result> ValidateRegister(RegisterRenterRequest request)
        {
            var result = new Result();
            result.IsSuccess = true;


            if((DateTime.Now.Year - request.Birth_Date.Year) < 18 && (DateTime.Now.Year - request.Birth_Date.Year) > 100)
                result.ValidateResult("Idade inválida");

            if(!DocumentHelper.ValidateDocument(request.Document))
                result.ValidateResult("Documento inválido");

            return result;
        }

        private async Task<Result> ValidateCnh(InsertRentalCNHRequest request)
        {
            var result = new Result();
            result.IsSuccess = true;

            var cnh = CnhHelper.ValidateCnh(request.Cnh);
            if (!cnh)
                result.ValidateResult("CNH inválida");

            var type_Cnh = CnhHelper.ValidateTypeCnh(request.Cnh_Type);
            if (!type_Cnh)
                result.ValidateResult("Categoria inválida");

            var cnh_Url = CnhHelper.ValidateUrl(request.Cnh_Img_Url);
            if (!cnh_Url)
                result.ValidateResult("Url inválido");
            return result;
        }
    }
}
