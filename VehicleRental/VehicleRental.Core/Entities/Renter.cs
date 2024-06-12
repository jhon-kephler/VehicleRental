using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleRental.Core.Entities
{
    [Table("renter")]
    public class Renter
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("document")]
        public string Document { get; set; }

        [Column("birth_date")]
        public DateTime Birth_Date { get; set; }

        [Column("cnh")]
        public string CNH { get; set; }

        [Column("cnh_type")]
        public string CNH_Type { get; set; }

        [Column("cnh_img_url")]
        public string CNH_Img_Url { get; set; }
        public RenterOrder RenterOrder { get; set; }
    }
}
