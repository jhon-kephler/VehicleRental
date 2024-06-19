using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Domain.Entities;

namespace VehicleRental.Data.Query.BrandQuery.Interfaces
{
    public interface IGetBrandByIdQuery
    {
        Task<Brands> GetByIdAsync(int Id);
    }
}
