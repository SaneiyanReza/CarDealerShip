using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Domain;
using ShopManegement.App.VehicleCategories;
using ShopManegment.App.Concrete;
using ShopManegment.Infrastructure.EfCore;
using ShopManegment.Infrastructure.EfCore.Repository;

namespace ShopManegment.Configuration
{
    public class ShopManegmentBootstrapper
    {
        public static void Configure(IServiceCollection services , string connectionString)
        {
            services.AddTransient<IVehicleCategoryApplication, VehicleCategoryApplication>();
            services.AddTransient<IVehicleCategoryRepository, VehicleCategoryRepository>();

            services.AddDbContext<CarDealerShipContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
