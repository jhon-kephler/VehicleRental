using VehicleRental.Domain.Entities;
using VehicleRental.Data.Query.VehicleQuery.Interfaces;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Data.Query.VehicleQuery
{
    public class GetVehicleByPlateQuery : IGetVehicleByPlateQuery
    {
        private IRepository<Vehicle> _repository;

        public GetVehicleByPlateQuery(IRepository<Vehicle> repository)
        {
            _repository = repository;
        }

        public async Task<Vehicle> GetByPlateAsync(string plate)
        {
            var result = new Vehicle();
            result = _repository.GetByPlate(plate);
            return result;
        }

    }
}
