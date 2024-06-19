using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Domain.Entities;
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

        public async Task<Renter> GetRenterByDocumentAsync(string document)
        {
            var result = new Renter();
            result = _repository.GetByDocument(document);
            return result;
        }

        public async Task<Renter> GetRenterByCnhAsync(string cnh)
        {
            var result = new Renter();
            result = _repository.GetByCnh(cnh);
            return result;
        }
    }
}
