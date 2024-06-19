using VehicleRental.Data.Command.VehicleCommand.Interfaces;
using VehicleRental.Domain.Entities;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Data.Command.VehicleCommand
{
    public class DeleteVehicleCommand : IDeleteVehicleCommand
    {
        private IRepository<Vehicle> _repository;

        public DeleteVehicleCommand(IRepository<Vehicle> repository)
        {
            _repository = repository;
        }

        public Task DeleteVehicle(int id)
        {
            try
            {
                _repository.Delete(id);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}
