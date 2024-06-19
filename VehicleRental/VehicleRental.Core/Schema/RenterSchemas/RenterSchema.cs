using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental.Core.Schema.RenterSchemas
{
    public class RenterSchema
    {
        public RenterSchema(int id, string name, string document, DateTime birth_Date, string? cNH, string? cNH_Type, string? cNH_Img_Url, DateTime? cNH_Expiration_Date)
        {
            Id = id;
            Name = name;
            Document = document;
            Birth_Date = birth_Date;
            CNH = cNH;
            CNH_Type = cNH_Type;
            CNH_Img_Url = cNH_Img_Url;
            CNH_Expiration_Date = cNH_Expiration_Date;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime Birth_Date { get; set; }
        public string? CNH { get; set; }
        public string? CNH_Type { get; set; }
        public string? CNH_Img_Url { get; set; }
        public DateTime? CNH_Expiration_Date { get; set; }
    }
}
