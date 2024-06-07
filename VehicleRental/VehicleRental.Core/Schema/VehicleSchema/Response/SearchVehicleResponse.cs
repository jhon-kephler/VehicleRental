using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental.Core.Schema.VehicleSchema.Response
{
    public class SearchVehicleResponse
    {
        public int Vehicle_Id { get; set; }

        public int Year_Vehicle { get; set; }

        public int Brand_Id { get; set; }

        public string Model { get; set; }

        public string Plate { get; set; }

        public int? Deliveryman_Id { get; set; }

    }
}
