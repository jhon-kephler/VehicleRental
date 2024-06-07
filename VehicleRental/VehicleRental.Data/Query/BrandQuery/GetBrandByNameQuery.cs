using VehicleRental.Core.Entities;
using VehicleRental.Data.Query.BrandQuery.Interfaces;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Data.Query.brandQuery
{
    public class GetBrandByNameQuery : IGetBrandByNameQuery
    {
        private IRepository<Brands> _repository;

        public GetBrandByNameQuery(IRepository<Brands> repository)
        {
            _repository = repository;
        }

        public async Task<Brands> GetByNameAsync(string brand_Name)
        {
            var result = new Brands();
            result = _repository.GetByName(brand_Name);
            return result;
        }

    }
}
