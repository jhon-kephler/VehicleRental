using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Response
{
    public class SearchRentalResponse
    {
        public int Rental_Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime Birth_Date { get; set; }
        public string Cnh { get; set; }
        public string Cnh_Type { get; set; }
        public string Cnh_Img_Url { get; set; }
        public DateTime Cnh_Expiration_Date { get; set; }
    }
}
