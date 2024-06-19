using VehicleRental.Domain.Entities;
using VehicleRental.Data.Query.BrandQuery.Interfaces;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Data.Query.brandQuery
{
    public class GetBrandByIdQuery : IGetBrandByIdQuery
    {
        private IRepository<Brands> _repository;

        public GetBrandByIdQuery(IRepository<Brands> repository)
        {
            _repository = repository;
        }

        public async Task<Brands> GetByIdAsync(int id)
        {
            var result = new Brands();
            result = _repository.GetById(id);
            return result;
        }

    }
}
