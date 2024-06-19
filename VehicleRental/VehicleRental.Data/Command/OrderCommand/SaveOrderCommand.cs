using VehicleRental.Domain.Entities;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Data.Command.OrderCommand
{
    public interface ISaveOrderCommand { Task SaveRenterOrder(RenterOrder request); }

    public class SaveOrderCommand : ISaveOrderCommand
    {
        private IRepository<RenterOrder> _repository;

        public SaveOrderCommand(IRepository<RenterOrder> repository)
        {
            _repository = repository;
        }

        public Task SaveRenterOrder(RenterOrder request)
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
