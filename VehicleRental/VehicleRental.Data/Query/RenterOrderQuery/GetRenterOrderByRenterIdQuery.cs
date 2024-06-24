using VehicleRental.Domain.Entities;
using VehicleRental.Data.Query.RenterOrderQuery.Interfaces;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Data.Query.RenterOrderQuery
{
    public class GetRenterOrderByRenterIdQuery : IGetRenterOrderByRenterIdQuery
    {
        private IRepository<RenterOrder> _repository;

        public GetRenterOrderByRenterIdQuery(IRepository<RenterOrder> repository)
        {
            _repository = repository;
        }

        public async Task<RenterOrder> GetByIdAsync(int id)
        {
            var result = new RenterOrder();
            result = _repository.GetById(id);
            return result;
        }

        public async Task<RenterOrder> GetByDocumentAsync(string document)
        {
            var result = new RenterOrder();
            result = _repository.GetByDocument(document);
            return result;
        }

        public async Task<RenterOrder> GetByCnhAsync(string cnh)
        {
            var result = new RenterOrder();
            result = _repository.GetByCnh(cnh);
            return result;
        }
    }
}
