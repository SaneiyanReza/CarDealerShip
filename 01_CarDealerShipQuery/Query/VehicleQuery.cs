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
                Price = x.UnitPrice.ToMoney()
            }).ToList();

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
    }
}
