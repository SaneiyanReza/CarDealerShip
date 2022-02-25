using _0_Framework.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.App.VehiclePicture
{
    public interface IVehiclePictureApplication
    {
        OperationResult Create(CreateVehiclePicture createVehiclePicture);
        OperationResult Edit(EditVehiclePicture editVehiclePicture);
        OperationResult Remove(int id);
        OperationResult Restore(int id);
        EditVehiclePicture GetDetails(int id);
        List<VehiclePictureViewModel> Search(VehiclePictureSearchModel searchModel);
    }
}
