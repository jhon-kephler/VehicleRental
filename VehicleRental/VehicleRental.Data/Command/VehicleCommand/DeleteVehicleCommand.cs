using VehicleRental.Data.Command.VehicleCommand.Interfaces;
using VehicleRental.Core.Entities;
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

        public Task DeleteVehicle(DeleteVehicleQuery request)
        {
            try
            {
                _repository.Delete(request.Id);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        public class DeleteVehicleQuery
        {
            public int Id { get; set; }
        }
    }
}
