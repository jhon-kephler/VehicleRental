using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental.Core.Entities
{
    [Table("vehicle")]
    public class Brands
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("brand_name")]
        public string Brand_Name { get; set; }

        [Column("type_vehicle")]
        public string Type_Vehicle { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}