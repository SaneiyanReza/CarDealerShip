using _01_CarDealerShipQuery;
using _01_CarDealerShipQuery.Contracts.VehicleCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IVehicleCategoryQuery _vehicleCategoryQuery;

        public MenuViewComponent(IVehicleCategoryQuery vehicleCategoryQuery)
        {
            _vehicleCategoryQuery = vehicleCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuModel
            {
                VehicleCategories = _vehicleCategoryQuery.GetVehicleCategories()
            };
            return View(result);
        }
    }
}
