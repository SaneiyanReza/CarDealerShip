using _01_CarDealerShipQuery.Contracts.VehicleCategory;
using ShopManegment.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CarDealerShipQuery.Query
{
    public class VehicleCategoryQuery : IVehicleCategoryQuery
    {
        private readonly CarDealerShipContext _Context;

        public VehicleCategoryQuery(CarDealerShipContext carDealerShipContext)
        {
            _Context = carDealerShipContext;
        }

        public List<VehicleCategoryQueryModel> GetVehicleCategories()
        {
            return _Context.VehicleCategories.Where(x => x.IsDeleted == false).Select(x => new VehicleCategoryQueryModel
            {
               ID = x.ID,
               Name = x.Name,
               Picture = x.Picture,
               PictureAlt = x.PictureAlt,
               PictureTitle = x.PictureTitle,
               Slug = x.Slug
            }).ToList();
        }
    }
}
