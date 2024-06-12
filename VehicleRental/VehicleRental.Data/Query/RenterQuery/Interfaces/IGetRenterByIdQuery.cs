using VehicleRental.Core.Entities;

namespace VehicleRental.Data.Query.RenterQuery.Interfaces
{
    public interface IGetRenterByIdQuery
    {
        Task<Renter> GetByIdAsync(int id);
    }
}