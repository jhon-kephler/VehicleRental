using AutoMapper;
using VehicleRental.Application.Services.RenterServices.Interfaces;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Request;
using VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Response;
using VehicleRental.Domain.Entities;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Application.Services.RenterServices
{
    public class SearchRentalService : ISearchRentalService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Renter> _renterRepository;

        public SearchRentalService(IMapper mapper, 
            IRepository<Renter> renterRepository)
        {
            _mapper = mapper;
            _renterRepository = renterRepository;
        }

        public async Task<Result<SearchRentalResponse>> SearchRentalById(SearchRentalByIdRequest request)
        {
            var result = new Result<SearchRentalResponse>();

            try
            {
                var rental = _renterRepository.GetById(request.Rental_Id);
                result.SetSuccess(_mapper.Map<SearchRentalResponse>(rental));
            }
            catch (Exception ex)
            {
                result.ValidateResult(ex.Message);
            }

            return result;
        }

        public async Task<Result<SearchRentalResponse>> SearchRentalByDocument(SearchRentalByDocumentRequest request)
        {
            var result = new Result<SearchRentalResponse>();

            try
            {
                var rental = _renterRepository.GetByDocument(request.Document);
                result.SetSuccess(_mapper.Map<SearchRentalResponse>(rental));
            }
            catch (Exception ex)
            {
                result.ValidateResult(ex.Message);
            }

            return result;
        }

        public async Task<Result<SearchRentalResponse>> SearchRentalByCnh(SearchRentalByCnhRequest request)
        {
            var result = new Result<SearchRentalResponse>();

            try
            {
                var rental = _renterRepository.GetByCnh(request.Cnh);
                result.SetSuccess(_mapper.Map<SearchRentalResponse>(rental));
            }
            catch (Exception ex)
            {
                result.ValidateResult(ex.Message);
            }

            return result;
        }
    }
}
