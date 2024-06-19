using VehicleRental.Data.Command.VehicleCommand.Interfaces;
using VehicleRental.Domain.Entities;
using VehicleRental.Data.Repositories;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Data.Command.VehicleCommand
{
    public class UpdateVehicleCommand : IUpdateVehicleCommand
    {
        private IRepository<Vehicle> _repository;

        public UpdateVehicleCommand(IRepository<Vehicle> repository)
        {
            _repository = repository;
        }

        public Task UpdateVehicle(Vehicle request)
        {
            try
            {
                _repository.Update(request.Id, request);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}
