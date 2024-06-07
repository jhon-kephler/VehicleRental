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

            modelBuilder.Entity<Deliveryman>()
                        .HasOne(d => d.DeliveryOrder)
                        .WithOne(o => o.Deliveryman)
                        .HasForeignKey<DeliveryOrder>(o => o.Deliveryman_Id);

            modelBuilder.Entity<Deliveryman>()
                        .HasOne(d => d.Vehicle)
                        .WithOne(o => o.Deliveryman)
                        .HasForeignKey<Vehicle>(o => o.Deliveryman_Id);
        }

        public DbSet<Deliveryman> Deliveryman { get; set; }
        public DbSet<DeliveryOrder> DeliveryOrder { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
    }
}