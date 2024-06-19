using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental.Core.Schema.OrderSchemas.Response
{
    public class OrderResponse
    {
        public OrderResponse()
        {
            
        }

        public OrderResponse(decimal rental_Value, string status, int? renter_Id, int vehicle_Id)
        {
            Rental_Value = rental_Value;
            Status = status;
            Renter_Id = renter_Id;
            Vehicle_Id = vehicle_Id;
        }

        public int Id { get; set; }
        public DateTime Created_Date { get; set; }
        public decimal Rental_Value { get; set; }
        public string Status { get; set; }
        public int? Renter_Id { get; set; }
        public int Vehicle_Id { get; set; }
    }
}
