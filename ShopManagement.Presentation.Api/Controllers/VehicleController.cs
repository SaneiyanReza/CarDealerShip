using _0_Framework.App;
using _01_CarDealerShipQuery.Contracts.Vehicle;
using Microsoft.AspNetCore.Mvc;
using ShopManegement.App.Vehicle;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagement.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleQuery _vehicleQuery;
        private readonly IVehicleApplication _vehicleApplication;

        public VehicleController(IVehicleQuery vehicleQuery , IVehicleApplication vehicleApplication)
        {
            _vehicleQuery = vehicleQuery;
            _vehicleApplication = vehicleApplication;
        }

        [HttpGet]
        public List<VehicleQueryModel> GetVehicles()
        {
            return _vehicleQuery.GetVehicles();
        }

        //[HttpPost]
        //public DiscountStatus CheckDiscount(IsDiscount discount)
        //{
        //    return _vehicleQuery.CheckDiscount(discount);
        //}

        [HttpPost]
        public List<VehicleQueryModel> Search(string value)
        {
            return _vehicleQuery.Search(value);
        }

        [HttpDelete("id")]
        public OperationResult DeleteVehicle([FromRoute] int id)
        {
           return _vehicleApplication.DeleteByID(id);
        }
    }
}
