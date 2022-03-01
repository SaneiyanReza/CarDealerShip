using _01_CarDealerShipQuery.Contracts.Vehicle;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class VehicleCategoryWithUsedVehicleViewComponent : ViewComponent
    {
        private readonly IVehicleQuery _vehicleQuery;

        public VehicleCategoryWithUsedVehicleViewComponent(IVehicleQuery vehicleQuery)
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
