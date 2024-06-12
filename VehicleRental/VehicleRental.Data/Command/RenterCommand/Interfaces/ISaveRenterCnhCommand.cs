using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Core.Entities;

namespace VehicleRental.Data.Command.RenterCommand.Interfaces
{
    public interface ISaveRenterCnhCommand
    {
        Task SaveCnhRenter(Renter request);
    }
}
