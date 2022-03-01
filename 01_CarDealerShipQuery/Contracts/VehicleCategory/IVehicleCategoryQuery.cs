using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CarDealerShipQuery.Contracts.VehicleCategory
{
    public interface IVehicleCategoryQuery
    {
        VehicleCategoryQueryModel GetVehicleCategoryWithVehicles(string slug);
        List<VehicleCategoryQueryModel> GetVehicleCategories();
        List<VehicleCategoryQueryModel> GetVehicleCategoriesWithVehicles();
    }
}
