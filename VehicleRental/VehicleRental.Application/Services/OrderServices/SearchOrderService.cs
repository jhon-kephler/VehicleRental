using AutoMapper;
using VehicleRental.Application.Services.OrderServices.Interfaces;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.OrderSchemas.Request;
using VehicleRental.Core.Schema.OrderSchemas.Response;
using VehicleRental.Domain.Entities;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Application.Services.OrderServices
{
    public class SearchOrderService : ISearchOrderService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<RenterOrder> _renterOrderRepository;

        public SearchOrderService(IMapper mapper, 
            IRepository<RenterOrder> renterOrderRepository)
        {
            _mapper = mapper;
            _renterOrderRepository = renterOrderRepository;
        }

        public async Task<Result<OrderResponse>> SearchOrderById(SearchOrderByIdRequest request)
        {
            var result = new Result<OrderResponse>();

            try
            {
                result.SetSuccess(_mapper.Map<OrderResponse>(_renterOrderRepository.GetById(request.Order_Id)));
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
                result.SetSuccess(_mapper.Map<OrderResponse>(_renterOrderRepository.GetByDocument(request.Document)));
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
                result.SetSuccess(_mapper.Map<OrderResponse>(_renterOrderRepository.GetByCnh(request.Cnh)));
            }
            catch (Exception ex)
            {
                result.ValidateResult(ex.Message);
            }

            return result;
        }
    }
}
