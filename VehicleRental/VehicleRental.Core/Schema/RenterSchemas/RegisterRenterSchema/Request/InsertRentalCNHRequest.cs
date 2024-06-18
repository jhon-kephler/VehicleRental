using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request
{
    public class InsertRentalCNHRequest : IRequest<Result>
    {
        public int Rental_Id { get; set; }
        public string Cnh { get; set; }
        public string Cnh_Type { get; set; }
        public string Cnh_Img_Url { get; set; }
        public DateTime Expiration_Date { get; set; }
    }
}
