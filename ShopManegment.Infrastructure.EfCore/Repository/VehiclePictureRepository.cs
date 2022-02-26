using ShopManagement.Domain.VehiclePictureAgg;
using _0_Framework.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManegement.App.VehiclePicture;
using Microsoft.EntityFrameworkCore;
using ShopManegement.App.Vehicle;
using _0_Framework.App;

namespace ShopManegment.Infrastructure.EfCore.Repository
{
    public class VehiclePictureRepository : RepositoryBase<int, VehiclePicture>, IVehiclePictureRepository
    {
        private readonly CarDealerShipContext _context;

        public VehiclePictureRepository(CarDealerShipContext context) : base(context)
        {
            _context = context;
        }

        public EditVehiclePicture GetDatails(int id)
        {
            return _context.VehiclePictures.Select(p => new EditVehiclePicture
            {
                ID = p.ID,
                Picture = p.Picture,
                PictureTitle = p.PictureTitle,
                PictureAlt = p.PictureAlt,
                VehicleID = p.VehicleID
            }
            ).FirstOrDefault(x => x.ID == id);
        }

        public List<VehiclePictureViewModel> Search(VehiclePictureSearchModel searchModel)
        {
            var query = _context.VehiclePictures.Include(p => p.Vehicle).Select(p => new VehiclePictureViewModel
            {
                ID = p.ID,
                VehicleName = p.Vehicle.Name,
                VehicleModel = p.Vehicle.Model,
                Picture = p.Picture,
                CreationDate = p.CreationDate.ToFarsi(),
                VehicleID = p.VehicleID,
                IsDeleted = p.IsDeleted
            });
            if (searchModel.VehicleID != 0)
            {
                query = query.Where(p => p.VehicleID == searchModel.VehicleID);
            }

            return query.OrderByDescending(p => p.ID).ToList();
        }
    }
}
