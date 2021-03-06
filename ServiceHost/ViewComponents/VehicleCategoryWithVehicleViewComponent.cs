using _01_CarDealerShipQuery.Contracts.Vehicle;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class VehicleCategoryWithVehicleViewComponent : ViewComponent
    {
        private readonly IVehicleQuery _vehicleQuery;

        public VehicleCategoryWithVehicleViewComponent(IVehicleQuery vehicleQuery)
        {
            _vehicleQuery = vehicleQuery;
        }

        public IViewComponentResult Invoke()
        {
            var vehicles = _vehicleQuery.GetVehicles();
            return View(vehicles);
        }
    }
}
