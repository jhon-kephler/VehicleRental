using VehicleRental.Domain.Entities;

namespace VehicleRental.Data.Query.RenterOrderQuery.Interfaces
{
    public interface IListRenterOrderByRenterIdQuery
    {
        Task<List<RenterOrder>> ListByIdAsync(int id);
    }
}