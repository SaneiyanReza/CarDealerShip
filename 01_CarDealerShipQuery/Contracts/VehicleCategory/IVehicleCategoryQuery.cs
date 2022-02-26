using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CarDealerShipQuery.Contracts.VehicleCategory
{
    public interface IVehicleCategoryQuery
    {
        List<VehicleCategoryQueryModel> GetVehicleCategories();
    }
}
