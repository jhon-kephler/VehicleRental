using Microsoft.EntityFrameworkCore;
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

            modelBuilder.Entity<Renter>()
                        .HasOne(d => d.RenterOrder)
                        .WithOne(o => o.Renter)
                        .HasForeignKey<RenterOrder>(o => o.Renter_Id);

            modelBuilder.Entity<Renter>()
                        .HasOne(d => d.Vehicle)
                        .WithOne(o => o.Renter)
                        .HasForeignKey<Vehicle>(o => o.Renter_Id);
        }

        public DbSet<Renter> Renterman { get; set; }
        public DbSet<RenterOrder> RenterOrder { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
    }
}