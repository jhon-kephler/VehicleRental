using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml;
using VehicleRental.Domain.Entities;

namespace VehicleRental.Data
{
    public class VehicleRentalContext : DbContext
    {
        public VehicleRentalContext(DbContextOptions<VehicleRentalContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var asembly = typeof(VehicleRentalContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(asembly);

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.ToTable("brands");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<Renter>(entity =>
            {
                entity.ToTable("renter");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Document).HasColumnName("document");
                entity.Property(e => e.Birth_Date).HasColumnName("birth_date");
                entity.Property(e => e.CNH).HasColumnName("cnh");
                entity.Property(e => e.CNH_Type).HasColumnName("cnh_type");
                entity.Property(e => e.CNH_Img_Url).HasColumnName("cnh_img_url");
                entity.Property(e => e.CNH_Expiration_Date).HasColumnName("cnh_expiration_date");
            });

            modelBuilder.Entity<RenterOrder>(entity =>
            {
                entity.ToTable("renterorder");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Rental_Value).HasColumnName("rental_value");
                entity.Property(e => e.Renter_Id).HasColumnName("renter_id");
                entity.Property(e => e.Vehicle_Id).HasColumnName("vehicle_id");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.Created_Date).HasColumnName("created_date");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicle");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Availability).HasColumnName("availability");
                entity.Property(e => e.Brand_Id).HasColumnName("brand_id");
                entity.Property(e => e.Year).HasColumnName("year");
                entity.Property(e => e.Model).HasColumnName("model");
                entity.Property(e => e.Plate).HasColumnName("plate");
            });

            modelBuilder
                .Entity<Renter>()
                .Property(p => p.Birth_Date)
                .HasConversion(v => v.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            modelBuilder.Entity<Renter>()
                        .HasOne(d => d.RenterOrder)
                        .WithOne(o => o.Renter)
                        .HasForeignKey<RenterOrder>(o => o.Renter_Id);

            modelBuilder.Entity<Brands>()
                        .HasOne(d => d.Vehicle)
                        .WithOne(o => o.Brands)
                        .HasForeignKey<Vehicle>(o => o.Brand_Id);

            modelBuilder.Entity<Vehicle>()
                        .HasOne(d => d.RenterOrder)
                        .WithOne(o => o.Vehicle)
                        .HasForeignKey<RenterOrder>(o => o.Vehicle_Id);

            modelBuilder
                .Entity<RenterOrder>()
                .Property(p => p.Created_Date)
                .HasConversion(v => v.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        }

        public DbSet<Renter> Renter { get; set; }
        public DbSet<RenterOrder> RenterOrder { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Brands> Brands { get; set; }
    }
}