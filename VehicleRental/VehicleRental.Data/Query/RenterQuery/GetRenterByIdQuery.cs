using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Core.Entities;
using VehicleRental.Data.Query.RenterQuery.Interfaces;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Data.Query.RenterQuery
{
    public class GetRenterByIdQuery : IGetRenterByIdQuery
    {
        private IRepository<Renter> _repository;

        public GetRenterByIdQuery(IRepository<Renter> repository)
        {
            _repository = repository;
        }

        public async Task<Renter> GetByIdAsync(int id)
        {
            var result = new Renter();
            result = _repository.GetById(id);
            return result;
        }
    }
}
