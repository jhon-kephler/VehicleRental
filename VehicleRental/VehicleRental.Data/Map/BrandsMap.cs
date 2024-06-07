using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleRental.Core.Entities;

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
                .Property(b => b.Brand_Name)
                .HasColumnType("character varying")
                .HasColumnName("brand_name")
                .IsRequired();

            builder
                .Property(b => b.Type_Vehicle)
                .HasColumnType("character varying")
                .HasColumnName("type_vehicle")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(b => b.Vehicle)
                .WithOne(a => a.Brands)
                .HasForeignKey<Vehicle>(b => b.Brand_Id);
        }
    }
}
