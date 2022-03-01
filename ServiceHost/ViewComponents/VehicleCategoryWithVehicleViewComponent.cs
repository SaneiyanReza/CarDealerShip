using _01_CarDealerShipQuery.Contracts.VehicleCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class VehicleCategoryWithVehicleViewComponent : ViewComponent
    {
        private readonly IVehicleCategoryQuery _vehicleCategoryQuery;

        public VehicleCategoryWithVehicleViewComponent(IVehicleCategoryQuery vehicleCategoryQuery)
        {
            _vehicleCategoryQuery = vehicleCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var cartegories = _vehicleCategoryQuery.GetVehicleCategoriesWithVehicles();
            return View(cartegories);
        }
    }
}
