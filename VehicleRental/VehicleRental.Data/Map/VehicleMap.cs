using Microsoft.EntityFrameworkCore;
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
                .Property(b => b.Year)
                .HasColumnType("integer")
                .HasColumnName("year")
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
                .HasOne(b => b.RenterOrder)
                .WithOne(a => a.Vehicle)
                .HasForeignKey<RenterOrder>(b => b.Vehicle_Id);

            builder
                .HasOne(b => b.Brands)
                .WithOne(v => v.Vehicle)
                .HasForeignKey<Vehicle>(b => b.Brand_Id)
                .HasPrincipalKey<Brands>(v => v.Id);
        }
    }
}
