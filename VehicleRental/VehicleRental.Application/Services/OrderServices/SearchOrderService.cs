using AutoMapper;
using VehicleRental.Application.Services.OrderServices.Interfaces;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.OrderSchemas.Request;
using VehicleRental.Core.Schema.OrderSchemas.Response;
using VehicleRental.Data.Query.RenterOrderQuery.Interfaces;

namespace VehicleRental.Application.Services.OrderServices
{
    public class SearchOrderService : ISearchOrderService
    {
        private readonly IMapper _mapper;
        private readonly IGetRenterOrderByRenterIdQuery _renterOrderByRenterIdQuery;

        public SearchOrderService(IMapper mapper, 
            IGetRenterOrderByRenterIdQuery renterOrderByRenterIdQuery)
        {
            _mapper = mapper;
            _renterOrderByRenterIdQuery = renterOrderByRenterIdQuery;
        }

        public async Task<Result<OrderResponse>> SearchOrderById(SearchOrderByIdRequest request)
        {
            var result = new Result<OrderResponse>();

            try
            {
                result.SetSuccess(_mapper.Map<OrderResponse>(await _renterOrderByRenterIdQuery.GetByIdAsync(request.Order_Id)));
            }
            catch (Exception ex)
            {
                result.ValidateResult(ex.Message);
            }

            return result;
        }

        public async Task<Result<OrderResponse>> SearchOrderByDocument(SearchOrderByDocumentRequest request)
        {
            var result = new Result<OrderResponse>();

            try
            {
                result.SetSuccess(_mapper.Map<OrderResponse>(await _renterOrderByRenterIdQuery.GetByDocumentAsync(request.Document)));
            }
            catch (Exception ex)
            {
                result.ValidateResult(ex.Message);
            }

            return result;
        }

        public async Task<Result<OrderResponse>> SearchOrderByCnh(SearchOrderByCnhRequest request)
        {
            var result = new Result<OrderResponse>();

            try
            {
                result.SetSuccess(_mapper.Map<OrderResponse>(await _renterOrderByRenterIdQuery.GetByCnhAsync(request.Cnh)));
            }
            catch (Exception ex)
            {
                result.ValidateResult(ex.Message);
            }

            return result;
        }
    }
}
