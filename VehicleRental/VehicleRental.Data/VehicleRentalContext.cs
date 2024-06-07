using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml;
using VehicleRental.Core.Entities;

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

            modelBuilder
                .Entity<Renter>()
                .Property(p => p.Birth_Date)
                .HasConversion(v => v.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            modelBuilder.Entity<Renter>()
                        .HasOne(d => d.RenterOrder)
                        .WithOne(o => o.Renter)
                        .HasForeignKey<RenterOrder>(o => o.Renter_Id);

            modelBuilder.Entity<Vehicle>()
                        .HasOne(d => d.RenterOrder)
                        .WithOne(o => o.Vehicle)
                        .HasForeignKey<RenterOrder>(o => o.Vehicle_Id);

            modelBuilder.Entity<Brands>()
                        .HasOne(d => d.Vehicle)
                        .WithOne(o => o.Brands)
                        .HasForeignKey<Vehicle>(o => o.Brand_Id);

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