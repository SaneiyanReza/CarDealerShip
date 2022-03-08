using _01_CarDealerShipQuery.Contracts.Vehicle;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShopManagement.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleQuery _vehicleQuery;

        public VehicleController(IVehicleQuery vehicleQuery)
        {
            _vehicleQuery = vehicleQuery;
        }

        [HttpGet]
        public List<VehicleQueryModel> GetVehicles()
        {
            return _vehicleQuery.GetVehicles();
        }
    }
}
