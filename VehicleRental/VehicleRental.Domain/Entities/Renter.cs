using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleRental.Domain.Entities
{
    public class Renter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime Birth_Date { get; set; }
        public string? CNH { get; set; }
        public string? CNH_Type { get; set; }
        public string? CNH_Img_Url { get; set; }
        public DateTime? CNH_Expiration_Date { get; set; }

        public RenterOrder RenterOrder { get; set; }
    }
}
