using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Core.Entities;

namespace VehicleRental.Data.Map
{
    public class RenterOrderMap
    {
        public RenterOrderMap(EntityTypeBuilder<RenterOrder> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(b => b.Id)
                .HasColumnType("integer")
                .HasColumnName("id")
                .IsRequired();

            builder
                .Property(b => b.Created_Date)
                .HasColumnType("timestamp")
                .HasColumnName("created_date")
                .IsRequired();

            builder
                .Property(b => b.Race_Value)
                .HasColumnType("numeric")
                .HasColumnName("race_value")
                .IsRequired();

            builder
                .Property(b => b.Status)
                .HasColumnType("character varying")
                .HasColumnName("status")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(b => b.Availability)
                .HasColumnType("boolean")
                .HasColumnName("availability")
                .IsRequired();

            builder
                .Property(b => b.Renter_Id)
                .HasColumnType("integer")
                .HasColumnName("deliveryman_id");

            builder.HasOne(b => b.Renter)
              .WithMany()
              .HasPrincipalKey(b => b.Id)
              .HasForeignKey(b => b.Renter_Id);
        }
    }
}
