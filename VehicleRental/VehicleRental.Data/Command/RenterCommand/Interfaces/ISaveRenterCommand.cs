using VehicleRental.Core.Entities;

namespace VehicleRental.Data.Command.RenterCommand.Interfaces
{
    public interface ISaveRenterCommand
    {
        Task SaveRenter(Renter request);
    }
}
