using static VehicleRental.Data.Command.VehicleCommand.DeleteVehicleCommand;

namespace VehicleRental.Data.Command.VehicleCommand.Interfaces
{
    public interface IDeleteVehicleCommand
    {
        Task DeleteVehicle(DeleteVehicleQuery request);
    }
}
