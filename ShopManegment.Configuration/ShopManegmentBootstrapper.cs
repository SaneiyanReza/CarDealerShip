using _01_CarDealerShipQuery.Contracts.Slide;
using _01_CarDealerShipQuery.Contracts.VehicleCategory;
using _01_CarDealerShipQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Domain;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Domain.VehicleAgg;
using ShopManagement.Domain.VehiclePictureAgg;
using ShopManegement.App.Slide;
using ShopManegement.App.Vehicle;
using ShopManegement.App.VehicleCategories;
using ShopManegement.App.VehiclePicture;
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

            services.AddTransient<IVehicleApplication, VehicleApplication>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();

            services.AddTransient<IVehiclePictureApplication, VehiclePictureApplication>();
            services.AddTransient<IVehiclePictureRepository, VehiclePictureRepository>();

            services.AddTransient<ISlideApplication, SlideApplication>();
            services.AddTransient<ISlideRepository, SlideRepository>();

            services.AddTransient<ISlideQuery, SlideQuery>();

            services.AddTransient<IVehicleCategoryQuery, VehicleCategoryQuery>();

            services.AddDbContext<CarDealerShipContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
