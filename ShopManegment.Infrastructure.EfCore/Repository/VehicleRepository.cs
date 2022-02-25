using _0_Framework.Infrastucture;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.VehicleAgg;
using ShopManegement.App.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegment.Infrastructure.EfCore.Repository
{
    public class VehicleRepository : RepositoryBase<int, Vehicle>, IVehicleRepository
    {
        private readonly CarDealerShipContext _context;
        public VehicleRepository(CarDealerShipContext context) : base(context)
        {
            _context = context;
        }

        public EditVehicle GetDetails(int id)
        {
            return _context.Vehicles.Select(c => new EditVehicle
            {
                ID = c.ID,
                Name = c.Name,
                Model = c.Model,
                CarFunction = c.CarFunction,
                UnitPrice = c.UnitPrice,
                ShortDescription = c.ShortDescription,
                Description = c.Description,
                Picture = c.Picture,
                PictureAlt = c.PictureAlt,
                PictureTitle = c.PictureTitle,
                Slug = c.Slug,
                Keyword = c.Keyword,
                MetaDescription = c.MetaDescription,
                CategoryID = c.CategoryID

            }).FirstOrDefault(x => x.ID == id);
        }

        public List<VehicleViewModel> GetVehicles()
        {
            return _context.Vehicles.Select(x => new VehicleViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Model = x.Model,
                CreationDate = x.CreationDate.ToString()
            }).ToList();
        }

        public List<VehicleViewModel> Search(VehicleSearchModel vehicleSearchModel)
        {
            var query = _context.Vehicles.Include(x => x.VehicleCategory).Select(x => new VehicleViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Model = x.Model,
                CarFunction = x.CarFunction,
                UnitPrice = x.UnitPrice,
                CategoryName = x.VehicleCategory.Name,
                CategoryID = x.CategoryID,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToString(),
                IsAvailable = x.IsAvailable
            });

            if (!string.IsNullOrWhiteSpace(vehicleSearchModel.Name))
            {
                query = query.Where(x => x.Name.Contains(vehicleSearchModel.Name));
            }
            if (!string.IsNullOrWhiteSpace(vehicleSearchModel.Model))
            {
                query = query.Where(x => x.Model.Contains(vehicleSearchModel.Model));
            }
            if (vehicleSearchModel.CarFunction != null)
            {
                query = query.Where(x => x.CarFunction == vehicleSearchModel.CarFunction);
            }
            if (vehicleSearchModel.CategoryID != 0)
            {
                query = query.Where(x => x.CategoryID == vehicleSearchModel.CategoryID);
            }

            return query.OrderByDescending(x => x.ID).ToList();
        }
    }
}
