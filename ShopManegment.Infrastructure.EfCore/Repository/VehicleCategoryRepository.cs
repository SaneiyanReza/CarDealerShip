using _0_Framework.Infrastucture;
using ShopManagement.Domain;
using ShopManagement.Domain.VehicleCategoryAgg;
using ShopManegement.App.VehicleCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegment.Infrastructure.EfCore.Repository
{
    public class VehicleCategoryRepository : RepositryBase<int , VehicleCategory> , IVehicleCategoryRepository
    {
        private readonly CarDealerShipContext _context;
        public VehicleCategoryRepository(CarDealerShipContext context) : base(context)
        {
            _context = context;
        }
        public EditVehicleCategory GetDetails(int id)
        {
            return _context.VehicleCategories.Select(c => new EditVehicleCategory()
            {
                ID = c.ID,
                Name = c.Name,
                Model = c.Model,
                Description = c.Description,
                Picture = c.Picture,
                PictureAlt = c.PictureAlt,
                PictureTitle = c.PictureTitle,
                Keyword = c.Keyword,
                MetaDescription = c.MetaDiscription,
                Slug = c.Slug,
            }).FirstOrDefault(x => x.ID == id);
        }

        public List<VehicleCategoryViewModel> Search(SearchVehicleCategory searchVehicleCategory)
        {
            var quary = _context.VehicleCategories.Select(x => new VehicleCategoryViewModel
            {
                ID = x.ID,
                Picture = x.Picture,
                Name = x.Name,
                Model = x.Model,
                CreationDate = x.CreationDate.ToString()
            });

            if (!string.IsNullOrWhiteSpace(searchVehicleCategory.Name))
            {
                quary = quary.Where(x => x.Name.Contains(searchVehicleCategory.Name));
            }
            if (!string.IsNullOrWhiteSpace(searchVehicleCategory.Model))
            {
                quary = quary.Where(x => x.Model.Contains(searchVehicleCategory.Model));
            }

            return quary.OrderByDescending(x => x.ID).ToList();
        }
    }
}
