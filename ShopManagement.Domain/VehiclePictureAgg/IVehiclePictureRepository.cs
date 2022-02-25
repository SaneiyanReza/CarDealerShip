using _0_Framework.Domain;
using ShopManegement.App.Vehicle;
using ShopManegement.App.VehiclePicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.VehiclePictureAgg
{
    public interface IVehiclePictureRepository : IRepository<int , VehiclePicture>
    {
        EditVehiclePicture GetDatails(int id);
        List<VehiclePictureViewModel> Search(VehiclePictureSearchModel searchModel);
    }
}
