using _01_CarDealerShipQuery.Contracts.Vehicle;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Presentation.Api.Controllers;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel 
    {
        public string Value;
        public List<VehicleQueryModel> Vehicles;
        private readonly IVehicleQuery _vehicleQuery;

        public SearchModel(IVehicleQuery vehicleQuery)
        {
            _vehicleQuery = vehicleQuery;
        }

        public void OnGet(string value)
        {
            Value = value;
            Vehicles = _vehicleQuery.Search(value);
        }
    }
}
