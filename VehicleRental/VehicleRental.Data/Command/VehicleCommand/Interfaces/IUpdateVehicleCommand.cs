using VehicleRental.Core.Entities;

namespace VehicleRental.Data.Command.VehicleCommand.Interfaces
{
    public interface IUpdateVehicleCommand
    {
        Task UpdateVehicle(Vehicle request);
    }
}
