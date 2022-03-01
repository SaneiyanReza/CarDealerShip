using _0_Framework.Domain;
using ShopManegement.App.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.VehicleAgg
{
    public interface IVehicleRepository : IRepository<int , Vehicle>
    {
        EditVehicle GetDetails(int id);

        List<VehicleViewModel> Search(VehicleSearchModel vehicleSearchModel);

        List<VehicleViewModel> GetVehicles();

        bool DeleteByID(int id);
    }
}
