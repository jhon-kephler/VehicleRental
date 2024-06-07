using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace VehicleRental.Core.Entities
{
    [Table("vehicle")]
    public class Vehicle
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("year_vehicle")]
        public int Year_Vehicle { get; set; }

        [Column("brand_id")]
        public int Brand_Id { get; set; }

        [Column("model")]
        public string Model { get; set; }

        [Column("plate")]
        public string Plate { get; set; }

        [Column("deliveryman_id")]
        public int? Deliveryman_Id { get; set; }

        public Deliveryman Deliveryman { get; set; }

        public Brands Brands { get; set; }

        public bool ValidatePlate()
        {
            if (string.IsNullOrWhiteSpace(Plate)) { return false; }

            if (Plate.Length > 8) { return false; }

            Plate = Plate.Replace("-", "").Trim();

            if (char.IsLetter(Plate, 4))
            {
                var mercosurStandard = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return mercosurStandard.IsMatch(Plate);
            }
            else
            {
                var normalPattern = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return normalPattern.IsMatch(Plate);
            }
        }
    }
}
