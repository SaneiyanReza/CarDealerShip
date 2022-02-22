using _0_Framework.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.App.Vehicle
{
    public interface IVehicleApplication
    {
        OperationResult Create(CreateVehicle createVehicle);
        OperationResult Edit(EditVehicle editVehicle);
        OperationResult IsAvailable(int id);
        OperationResult IsNotAvailable(int id);
        EditVehicle GetDetails(int id);
        List<VehicleViewModel> Search(VehicleSearchModel searchModel);
        
    }
}
