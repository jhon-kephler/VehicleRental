namespace VehicleRental.Data.Command.VehicleCommand.Interfaces
{
    public interface IDeleteVehicleCommand
    {
        Task DeleteVehicle(int id);
    }
}
