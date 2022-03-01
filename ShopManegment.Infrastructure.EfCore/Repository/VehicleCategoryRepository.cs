using _0_Framework.App;
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
    public class VehicleCategoryRepository : RepositoryBase<int , VehicleCategory> , IVehicleCategoryRepository
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
                Description = c.Description,
                Picture = c.Picture,
                PictureAlt = c.PictureAlt,
                PictureTitle = c.PictureTitle,
                Keyword = c.Keyword,
                MetaDescription = c.MetaDiscription,
                Slug = c.Slug,
            }).FirstOrDefault(x => x.ID == id);
        }

        public List<VehicleCategoryViewModel> GetVehicleCategories()
        {
            return _context.VehicleCategories.Select(x => new VehicleCategoryViewModel
            {
                ID = x.ID,
                Name = x.Name,
            }).ToList();
        }

        public List<VehicleCategoryViewModel> Search(SearchVehicleCategory searchVehicleCategory)
        {
            var quary = _context.VehicleCategories.Select(x => new VehicleCategoryViewModel
            {
                ID = x.ID,
                Picture = x.Picture,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved
            });

            if (!string.IsNullOrWhiteSpace(searchVehicleCategory.Name))
            {
                quary = quary.Where(x => x.Name.Contains(searchVehicleCategory.Name));
            }

            return quary.OrderByDescending(x => x.ID).ToList();
        }
    }
}
