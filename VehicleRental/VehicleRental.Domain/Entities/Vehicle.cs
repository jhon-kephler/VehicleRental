using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace VehicleRental.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
        public int Brand_Id { get; set; }
        public bool Availability { get; set; }

        public Brands Brands { get; set; }
        public RenterOrder RenterOrder { get; set; }

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
