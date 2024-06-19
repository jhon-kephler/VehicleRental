using VehicleRental.Domain.Entities;

namespace VehicleRental.Data.Command.RenterCommand.Interfaces
{
    public interface ISaveRenterCnhCommand
    {
        Task SaveCnhRenter(Renter request);
    }
}
