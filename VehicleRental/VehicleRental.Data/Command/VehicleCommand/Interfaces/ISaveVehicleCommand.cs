using VehicleRental.Domain.Entities;

namespace VehicleRental.Data.Command.VehicleCommand.Interfaces
{
    public interface ISaveVehicleCommand
    {
        Task SaveVehicle(Vehicle request);
    }
}
