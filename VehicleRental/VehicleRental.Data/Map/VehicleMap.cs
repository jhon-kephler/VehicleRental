﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleRental.Core.Entities;

namespace VehicleRental.Data.Map
{
    public class VehicleMap
    {
        public VehicleMap(EntityTypeBuilder<Vehicle> builder)
        {
            builder
                .HasKey(x => x.Id)
                .HasName("id");

            builder
                .Property(b => b.Id)
                .HasColumnType("integer")
                .HasColumnName("id")
                .IsRequired();

            builder
                .Property(b => b.Year_Vehicle)
                .HasColumnType("integer")
                .HasColumnName("year_vehicle")
                .IsRequired();

            builder
                .Property(b => b.Brand_Id)
                .HasColumnType("integer")
                .HasColumnName("brand")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(b => b.Model)
                .HasColumnType("character varying")
                .HasColumnName("model")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(b => b.Plate)
                .HasColumnType("character varying")
                .HasColumnName("plate")
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(b => b.Deliveryman_Id)
                .HasColumnType("integer")
                .HasColumnName("deliveryman_id");

            builder.HasOne(b => b.Deliveryman)
              .WithMany()
              .HasPrincipalKey(b => b.Id)
              .HasForeignKey(b => b.Deliveryman_Id);

            builder
                .HasOne(b => b.Brands)
                .WithOne(a => a.Vehicle)
                .HasForeignKey<Brands>(b => b.Id);
        }
    }
}