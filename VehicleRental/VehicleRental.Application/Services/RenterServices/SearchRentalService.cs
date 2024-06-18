using AutoMapper;
using VehicleRental.Application.Services.RenterServices.Interfaces;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Request;
using VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Response;
using VehicleRental.Data.Query.RenterQuery.Interfaces;

namespace VehicleRental.Application.Services.RenterServices
{
    public class SearchRentalService : ISearchRentalService
    {
        private readonly IMapper _mapper;
        private readonly IGetRenterByIdQuery _getRenterByIdQuery;

        public SearchRentalService(IMapper mapper, IGetRenterByIdQuery getRenterByIdQuery)
        {
            _mapper = mapper;
            _getRenterByIdQuery = getRenterByIdQuery;
        }

        public async Task<Result<SearchRentalResponse>> SearchRentalById(SearchRentalByIdRequest request)
        {
            var result = new Result<SearchRentalResponse>();

            try
            {
                var rental = await _getRenterByIdQuery.GetByIdAsync(request.Rental_Id);
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
                var rental = await _getRenterByIdQuery.GetRenterByDocumentAsync(request.Document);
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
                var rental = await _getRenterByIdQuery.GetRenterByCnhAsync(request.Cnh);
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
