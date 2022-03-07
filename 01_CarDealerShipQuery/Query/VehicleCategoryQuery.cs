using _0_Framework.App;
using _01_CarDealerShipQuery.Contracts.Vehicle;
using _01_CarDealerShipQuery.Contracts.VehicleCategory;
using DiscountManegment.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.VehicleAgg;
using ShopManegment.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_CarDealerShipQuery.Query
{
    public class VehicleCategoryQuery : IVehicleCategoryQuery
    {
        private readonly CarDealerShipContext _context;
        private readonly DiscountContext _discountcontext;
        public VehicleCategoryQuery(CarDealerShipContext carDealerShipContext, DiscountContext discountContext)
        {
            _context = carDealerShipContext;
            _discountcontext = discountContext;
        }

        public List<VehicleCategoryQueryModel> GetVehicleCategories()
        {
            return _context.VehicleCategories.Where(x => x.IsRemoved == false).Select(x => new VehicleCategoryQueryModel
            {
                ID = x.ID,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).AsNoTracking().ToList();
        }

        public List<VehicleCategoryQueryModel> GetVehicleCategoriesWithVehicles()
        {
            var vehicles = _context.Vehicles.Select(x => new { x.ID, x.UnitPrice }).ToList();
            var discounts = _discountcontext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.VehicleID }).ToList();
            var categories = _context.VehicleCategories.Include(x => x.Vehicles)
                .ThenInclude(x => x.VehicleCategory).Select(x => new VehicleCategoryQueryModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    Vehicles = MapVehicles(x.Vehicles)
                }).AsNoTracking().ToList();

            foreach (var category in categories)
            {
                foreach (var vehicle in category.Vehicles)
                {
                    var vehicleModel = vehicles.FirstOrDefault(x => x.ID == vehicle.ID);
                    if (vehicleModel != null)
                    {
                        var price = vehicleModel.UnitPrice;
                        var discount = discounts.FirstOrDefault(x => x.VehicleID == vehicle.ID);
                        if (discount != null)
                        {
                            double discountRate = discount.DiscountRate;
                            vehicle.DiscountRate = discountRate;
                            vehicle.HasDiscount = discountRate > 0;
                            var discountAmount = Math.Round((price * discountRate) / 100);
                            vehicle.PriceWithDiscount = (price - discountAmount).ToMoney();
                        }
                    }
                }
            }
            return categories;
        }

        private static List<VehicleQueryModel> MapVehicles(List<Vehicle> vehicles)
        {
            var result = new List<VehicleQueryModel>();
            foreach (var vehicle in vehicles)
            {
                var item = new VehicleQueryModel
                {
                    ID = vehicle.ID,
                    Category = vehicle.VehicleCategory.Name,
                    Specifications = vehicle.Specifications,
                    Picture = vehicle.Picture,
                    PictureAlt = vehicle.PictureAlt,
                    PictureTitle = vehicle.PictureTitle,
                    Slug = vehicle.Slug,
                    Price = vehicle.UnitPrice.ToMoney()
                };
                result.Add(item);
            }
            return result;
        }

        public VehicleCategoryQueryModel GetVehicleCategoryWithVehicles(string slug)
        {
            var vehicles = _context.Vehicles.Select(x => new { x.ID, x.UnitPrice }).ToList();
            var discounts = _discountcontext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.VehicleID , x.EndDate}).ToList();
            var category = _context.VehicleCategories.Include(x => x.Vehicles)
                .ThenInclude(x => x.VehicleCategory).Select(x => new VehicleCategoryQueryModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    Vehicles = MapVehicles(x.Vehicles),
                    MetaDescription = x.MetaDiscription,
                    Description = x.Description,
                    Keyword = x.Keyword,
                    Slug = x.Slug
                }).ToList().FirstOrDefault(x => x.Slug == slug);


            foreach (var vehicle in category.Vehicles)
            {
                var vehicleModel = vehicles.FirstOrDefault(x => x.ID == vehicle.ID);
                if (vehicleModel != null)
                {
                    var price = vehicleModel.UnitPrice;
                    var discount = discounts.FirstOrDefault(x => x.VehicleID == vehicle.ID);
                    if (discount != null)
                    {
                        double discountRate = discount.DiscountRate;
                        vehicle.DiscountRate = discountRate;
                        vehicle.DiscountExpire = discount.EndDate.ToDiscountFormat();
                        vehicle.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        vehicle.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }
                }
            }
            return category;
        }
    }
}
