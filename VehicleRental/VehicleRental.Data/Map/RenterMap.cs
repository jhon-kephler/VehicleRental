using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleRental.Core.Entities;

namespace VehicleRental.Data.Map
{
    public class RenterMap
    {
        public RenterMap(EntityTypeBuilder<Renter> builder)
        {
            builder
                .HasKey(x => x.Id);

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
                .Property(b => b.CNPJ)
                .HasColumnType("character varying")
                .HasColumnName("cnpj")
                .HasMaxLength(14)
                .IsRequired();

            builder
                .Property(b => b.Birth_Date)
                .HasColumnType("timestamp")
                .HasColumnName("birth_date")
                .IsRequired();

            builder
                .Property(b => b.CNH)
                .HasColumnType("character varying")
                .HasColumnName("cnh")
                .HasMaxLength(11)
                .IsRequired();

            builder
                .Property(b => b.CNH_Type)
                .HasColumnType("character varying")
                .HasColumnName("id")
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(b => b.CNH_Img)
                .HasColumnType("character varying")
                .HasColumnName("cnh_img")
                .HasMaxLength(250)
                .IsRequired();

            builder
                .HasOne(b => b.Vehicle)
                .WithOne(a => a.Renter)
                .HasForeignKey<Vehicle>(b => b.Renter_Id);

            builder
                .HasOne(b => b.RenterOrder)
                .WithOne(a => a.Renter)
                .HasForeignKey<RenterOrder>(b => b.Renter_Id);
        }
    }
}
