﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Domain.Entities;

namespace VehicleRental.Data.Query.VehicleQuery.Interfaces
{
    public interface IGetVehicleByIdQuery
    {
        Task<Vehicle> GetByIdAsync(int id);
    }
}
