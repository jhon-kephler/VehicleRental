using VehicleRental.Domain.Entities;
using VehicleRental.Data.Query.RenterOrderQuery.Interfaces;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Data.Query.RenterOrderQuery
{
    public class ListRenterOrderByRenterIdQuery : IListRenterOrderByRenterIdQuery
    {
        private IRepository<RenterOrder> _repository;

        public ListRenterOrderByRenterIdQuery(IRepository<RenterOrder> repository)
        {
            _repository = repository;
        }

        public async Task<List<RenterOrder>> ListByIdAsync(int id)
        {
            var result = new List<RenterOrder>();
            result = await _repository.FindByConditionAsync(ro => ro.Vehicle_Id == id);
            return result;
        }
    }
}
