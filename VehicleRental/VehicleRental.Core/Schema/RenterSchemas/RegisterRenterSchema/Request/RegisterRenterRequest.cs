using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request
{
    public class RegisterRenterRequest : IRequest<Result>
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime Birth_Date { get; set; }
        public string CNH { get; set; }
        public string CNH_Type { get; set; }
        public string CNH_Img { get; set; }
    }
}
