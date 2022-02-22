using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.VehicleAgg;
using ShopManagement.Domain.VehicleCategoryAgg;
using ShopManegment.Infrastructure.EfCore.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegment.Infrastructure.EfCore
{
    public class CarDealerShipContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }

        public CarDealerShipContext(DbContextOptions<CarDealerShipContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly= typeof(VehicleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }

}
