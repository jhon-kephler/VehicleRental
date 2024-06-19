using VehicleRental.Data.Command.VehicleCommand.Interfaces;
using VehicleRental.Domain.Entities;
using VehicleRental.Data.Repositories;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Data.Command.VehicleCommand
{
    public class SaveVehicleCommand : ISaveVehicleCommand
    {
        private IRepository<Vehicle> _repository;

        public SaveVehicleCommand(IRepository<Vehicle> repository)
        {
            _repository = repository;
        }

        public Task SaveVehicle(Vehicle request)
        {
            try
            {
                _repository.Add(request);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}
