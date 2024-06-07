using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Core.Entities;

namespace VehicleRental.Data.Query.BrandQuery.Interfaces
{
    public interface IGetBrandByNameQuery
    {
        Task<Brands> GetByNameAsync(string brand_Name);
    }
}
