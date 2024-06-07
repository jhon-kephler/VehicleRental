using VehicleRental.Core.Entities;
using VehicleRental.Data.Command.RenterCommand.Interfaces;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Data.Command.RenterCommand
{
    public class SaveRenterCommand : ISaveRenterCommand
    {
        private IRepository<Renter> _repository;

        public SaveRenterCommand(IRepository<Renter> repository)
        {
            _repository = repository;
        }

        public Task SaveRenter(Renter request)
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
