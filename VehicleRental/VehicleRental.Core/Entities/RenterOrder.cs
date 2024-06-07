using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleRental.Core.Entities
{
    [Table("renterorder")]
    public class RenterOrder
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("created_date")]
        public DateTime Created_Date { get; set; }

        [Column("race_value")]
        public decimal Race_Value { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("availability")]
        public bool Availability { get; set; }

        [Column("renter_id")]
        public int? Renter_Id { get; set; }
        public Renter Renter { get; set; }
    }
}
