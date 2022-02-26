using _01_CarDealerShipQuery.Contracts.VehicleCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class VehicleCategoryViewComponent : ViewComponent
    {
        private readonly IVehicleCategoryQuery _VehicleCategoryQuery;

        public VehicleCategoryViewComponent(IVehicleCategoryQuery vehicleCategoryQuery)
        {
            _VehicleCategoryQuery = vehicleCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var vehicleCategories = _VehicleCategoryQuery.GetVehicleCategories();
            return View(vehicleCategories);
        }
    }
}
