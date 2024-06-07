﻿using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleRental.Core.Entities
{
    [Table("deliveryorder")]
    public class RenterOrder
    {
        [Column("id")]
        public int Id { get; private set; }

        [Column("created_date")]
        public DateTime Created_Date { get; private set; }

        [Column("race_value")]
        public decimal Race_Value { get; private set; }

        [Column("status")]
        public string Status { get; private set; }

        [Column("availability")]
        public bool Availability { get; private set; }

        [Column("deliveryman_id")]
        public int? Renter_Id { get; private set; }
        public Renter Renter { get; private set; }
    }
}