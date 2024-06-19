using VehicleRental.Domain.Entities;
using VehicleRental.Data.Query.VehicleQuery.Interfaces;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Data.Query.VehicleQuery
{
    public class GetVehicleByIdQuery : IGetVehicleByIdQuery
    {
        private IRepository<Vehicle> _repository;

        public GetVehicleByIdQuery(IRepository<Vehicle> repository)
        {
            _repository = repository;
        }

        public async Task<Vehicle> GetByIdAsync(int id)
        {
            var result = new Vehicle();
            result = _repository.GetById(id);
            return result;
        }

    }
}
