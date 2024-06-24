using VehicleRental.Domain.Entities;

namespace VehicleRental.Data.Query.RenterOrderQuery.Interfaces
{
    public interface IGetRenterOrderByRenterIdQuery
    {
        Task<RenterOrder> GetByIdAsync(int id);
        Task<RenterOrder> GetByDocumentAsync(string cnh);
        Task<RenterOrder> GetByCnhAsync(string cnh);
    }
}