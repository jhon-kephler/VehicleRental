using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleRental.Domain.Entities;

namespace VehicleRental.Data.Map
{
    public class BrandsMap
    {
        public BrandsMap(EntityTypeBuilder<Brands> builder)
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
                .Property(b => b.Name)
                .HasColumnType("character varying")
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(b => b.Type)
                .HasColumnType("character varying")
                .HasColumnName("type")
                .HasMaxLength(10)
                .IsRequired();

            builder
                .HasOne(b => b.Vehicle)
                .WithOne(a => a.Brands)
                .HasForeignKey<Vehicle>(b => b.Brand_Id);
        }
    }
}
