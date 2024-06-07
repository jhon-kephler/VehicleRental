using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleRental.Core.Entities
{
    public class Deliveryman
    {
        [Column("id")]
        public int Id { get; private set; }

        [Column("name")]
        public string Name { get; private set; }

        [Column("cnpj")]
        public string CNPJ { get; private set; }

        [Column("birth_date")]
        public DateTime Birth_Date { get; private set; }

        [Column("cnh")]
        public string CNH { get; private set; }

        [Column("cnh_type")]
        public string CNH_Type { get; private set; }

        [Column("cnh_img")]
        public string CNH_Img { get; private set; }
        public DeliveryOrder DeliveryOrder { get; private set; }
        public Vehicle Vehicle { get; private set; }
    }
}
