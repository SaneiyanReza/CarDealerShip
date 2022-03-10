using _01_CarDealerShipQuery.Contracts.Vehicle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class VehicleModel : PageModel
    {
        public VehicleQueryModel Vehicle;
        private readonly IVehicleQuery _VehicleQuery;

        public VehicleModel(IVehicleQuery VehicleQuery)
        {
            _VehicleQuery = VehicleQuery;
        }

        public void OnGet(string id)
        {
            Vehicle = _VehicleQuery.GetDetails(id);
        }

        public IActionResult OnPost(string VehicleSlug)
        {
            return RedirectToPage("/Vehicle", new { Id = VehicleSlug });
        }
    }
}
