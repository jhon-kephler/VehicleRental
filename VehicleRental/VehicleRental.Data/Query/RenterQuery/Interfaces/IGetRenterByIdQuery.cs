using VehicleRental.Domain.Entities;

namespace VehicleRental.Data.Query.RenterQuery.Interfaces
{
    public interface IGetRenterByIdQuery
    {
        Task<Renter> GetByIdAsync(int id);
        Task<Renter> GetRenterByCnhAsync(string cnh);
        Task<Renter> GetRenterByDocumentAsync(string cnh);
    }
}