using _01_CarDealerShipQuery.Contracts.VehicleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Domain.VehicleAgg;
using ShopManagement.Domain.VehicleCategoryAgg;

namespace ServiceHost.Pages
{
    public class VehicleCategoryModel : PageModel 
    {
        public VehicleCategoryQueryModel VehicleCategory;
        private readonly IVehicleCategoryQuery _vehicleCategoryQuery;

        public VehicleCategoryModel(IVehicleCategoryQuery vehicleCategoryQuery)
        {
            _vehicleCategoryQuery = vehicleCategoryQuery;
        }

        public void OnGet(string id)
        {
            VehicleCategory = _vehicleCategoryQuery.GetVehicleCategoryWithVehicles(id);
        }
    }
}
