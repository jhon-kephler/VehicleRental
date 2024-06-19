using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleRental.Domain.Entities
{
    [Table("renterorder")]
    public class RenterOrder
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("created_date")]
        public DateTime Created_Date { get; set; }

        [Column("rental_value")]
        public decimal Rental_Value { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("renter_id")]
        public int? Renter_Id { get; set; }

        [Column("vehicle_id")]
        public int Vehicle_Id { get; set; }

        public Renter Renter { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}