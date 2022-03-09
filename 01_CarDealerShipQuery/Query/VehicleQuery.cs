using _0_Framework.App;
using _01_CarDealerShipQuery.Contracts.Vehicle;
using DiscountManegment.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManegment.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CarDealerShipQuery.Query
{
    public class VehicleQuery : IVehicleQuery
    {
        private readonly CarDealerShipContext _context;
        private readonly DiscountContext _discountcontext;
        public VehicleQuery(CarDealerShipContext carDealerShipContext, DiscountContext discountContext)
        {
            _context = carDealerShipContext;
            _discountcontext = discountContext;
        }

        //public DiscountStatus CheckDiscount(Vehicle command)
        //{
        //    var vehicle = _context.Vehicles.FirstOrDefault(x => x.ID == command.VehicleID);
        //    var discount = _discountcontext.CustomerDiscounts.FirstOrDefault(x => x.VehicleID == command.VehicleID);
        //    if (vehicle == null || !vehicle.IsAvailable || discount == null)
        //    {
        //        return new DiscountStatus()
        //        {
        //            IsDiscount = false,
        //            Specification = vehicle?.Specifications
        //        };
        //    }

        //    return new DiscountStatus()
        //    {
        //        DiscountRate = discount.DiscountRate,
        //        Specification = vehicle?.Specifications
        //    };
        //}

        public List<VehicleQueryModel> GetVehicles()
        {
            var vehicles = _context.Vehicles.Select(x => new { x.ID, x.UnitPrice }).ToList();
            var discounts = _discountcontext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.VehicleID }).ToList();
            var vehicleQueryModels = _context.Vehicles.Include(x => x.VehicleCategory).Select(x => new VehicleQueryModel
            {
                ID = x.ID,
                Category = x.VehicleCategory.Name,
                Specifications = x.Specifications,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Price = x.UnitPrice.ToMoney(),
                ShortDescription = x.ShortDescription,
                CategorySlug = x.VehicleCategory.Slug,
                CreationDate = x.CreationDate
            }).AsNoTracking().OrderByDescending(x => x.ID).Take(20).ToList();

            foreach (var vehicle in vehicleQueryModels)
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
            return vehicleQueryModels;
        }

        public List<VehicleQueryModel> Search(string value)
        {
            var vehicles = _context.Vehicles.Select(x => new { x.ID, x.UnitPrice }).ToList();
            var discounts = _discountcontext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.VehicleID, x.EndDate }).ToList();

            var query = _context.Vehicles.Include(x => x.VehicleCategory)
                .Select(vehicle => new VehicleQueryModel
                {
                    ID = vehicle.ID,
                    Category = vehicle.VehicleCategory.Name,
                    VehicleName = vehicle.Name.ToLower(),
                    VehicleModel = vehicle.Model.ToLower(),
                    Picture = vehicle.Picture,
                    PictureAlt = vehicle.PictureAlt,
                    PictureTitle = vehicle.PictureTitle,
                    Slug = vehicle.Slug,
                    Price = vehicle.UnitPrice.ToMoney(),
                    ShortDescription = vehicle.ShortDescription.ToLower(),
                    CategorySlug = vehicle.VehicleCategory.Slug,
                }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(value))
            {
                query = query.Where(x => x.VehicleName.Contains(value.ToLower()) || x.VehicleModel.Contains(value.ToLower()) || x.ShortDescription.Contains(value.ToLower()));
            }

            var vehiclesModel = query.OrderByDescending(x => x.ID).ToList();

            foreach (var vehicle in vehiclesModel)
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
            return vehiclesModel;
        }
    }
}
