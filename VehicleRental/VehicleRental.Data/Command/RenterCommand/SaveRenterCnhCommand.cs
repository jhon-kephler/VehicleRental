using VehicleRental.Domain.Entities;
using VehicleRental.Data.Command.RenterCommand.Interfaces;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Data.Command.RenterCommand
{
    public class SaveRenterCnhCommand : ISaveRenterCnhCommand
    {
        private IRepository<Renter> _repository;

        public SaveRenterCnhCommand(IRepository<Renter> repository)
        {
            _repository = repository;
        }

        public Task SaveCnhRenter(Renter request)
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
