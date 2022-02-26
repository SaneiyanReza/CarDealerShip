using _0_Framework.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.App.VehicleCategories
{
    public interface IVehicleCategoryApplication
    {
        OperationResult Create(CreateVehicleCategory createVehicleCategory);
        OperationResult Edit(EditVehicleCategory editVehicleCategory);
        OperationResult Remove(int Id);
        OperationResult Restore(int Id);
        EditVehicleCategory GetDetail(int id);
        List<VehicleCategoryViewModel> GetVehicleCategories();
        List<VehicleCategoryViewModel> Search(SearchVehicleCategory searchVehicleCategory);
    }
}
