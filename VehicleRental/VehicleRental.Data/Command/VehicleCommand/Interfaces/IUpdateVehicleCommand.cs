using VehicleRental.Domain.Entities;

namespace VehicleRental.Data.Command.VehicleCommand.Interfaces
{
    public interface IUpdateVehicleCommand
    {
        Task UpdateVehicle(Vehicle request);
    }
}
