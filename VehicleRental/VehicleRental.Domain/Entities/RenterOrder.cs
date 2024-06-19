using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleRental.Domain.Entities
{
    public class RenterOrder
    {
        public int Id { get; set; }
        public DateTime Created_Date { get; set; }
        public decimal Rental_Value { get; set; }
        public string Status { get; set; }
        public int? Renter_Id { get; set; }
        public int Vehicle_Id { get; set; }

        public Renter Renter { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}