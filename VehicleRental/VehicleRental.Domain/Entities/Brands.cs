using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental.Domain.Entities
{
    public class Brands
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}