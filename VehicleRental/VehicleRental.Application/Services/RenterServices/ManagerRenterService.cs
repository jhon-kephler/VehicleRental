using AutoMapper;
using VehicleRental.Core.Helper;
using VehicleRental.Application.Services.RenterServices.Interfaces;
using VehicleRental.Domain.Entities;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request;
using VehicleRental.Data.Command.RenterCommand.Interfaces;
using VehicleRental.Core.Schema.RenterSchemas;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Application.Services.RenterServices
{
    public class ManagerRenterService : IManagerRenterService
    {
        public readonly IMapper _mapper;
        public readonly ISaveRenterCommand _saveRenterCommand;
        public readonly ISaveRenterCnhCommand _saveRenterCnhCommand;
        public readonly IRepository<Renter> _renterRepository;

        public ManagerRenterService(IMapper mapper, 
            ISaveRenterCommand saveRenterCommand, 
            ISaveRenterCnhCommand saveRenterCnhCommand,
            IRepository<Renter> renterRepository)
        {
            _mapper = mapper;
            _saveRenterCommand = saveRenterCommand;
            _saveRenterCnhCommand = saveRenterCnhCommand;
            _renterRepository = renterRepository;
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

            var renter = _renterRepository.GetById(request.Rental_Id);
            if(renter == null)
            {
                result.ValidateResult("Renter_Id inválido");
                return result;
            }

            try
            {
                var renterSchema = new RenterSchema(request.Rental_Id, renter.Name,renter.Document, renter.Birth_Date, request.Cnh, 
                                                    request.Cnh_Type, request.Cnh_Img_Url, request.Expiration_Date);

                await _saveRenterCnhCommand.SaveCnhRenter(_mapper.Map<Renter>(renterSchema));
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

            if(request.Expiration_Date.Date < DateTime.Now.Date)
                result.ValidateResult("Cnh expirada");

            return result;
        }
    }
}
