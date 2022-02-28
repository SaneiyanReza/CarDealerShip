using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ShopManegement.App.Vehicle;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManegement.App.VehicleCategories;

namespace ServiceHost.Areas.Administration.Pages.Shop.Vehicle
{
    //[Authorize(Roles = "1, 3")]
    public class IndexModel : PageModel
    {
        public VehicleSearchModel SearchModel;
        public List<VehicleViewModel> Vehicles;
        public SelectList VehicleCategories;

        private readonly IVehicleApplication _vehicleApplication;
        private readonly IVehicleCategoryApplication _vehicleCategoryApplication;

        public IndexModel(IVehicleApplication productApplication , IVehicleCategoryApplication vehicleCategoryApplication)
        {
            _vehicleApplication = productApplication;
            _vehicleCategoryApplication = vehicleCategoryApplication;
        }

        public void OnGet(VehicleSearchModel searchModel)
        {
            VehicleCategories = new SelectList(_vehicleCategoryApplication.GetVehicleCategories(), "ID", "Name");
            Vehicles = _vehicleApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateVehicle
            {
                Categories = _vehicleCategoryApplication.GetVehicleCategories()
            };

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateVehicle command)
        {
            var result = _vehicleApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var vehicle = _vehicleApplication.GetDetails(id);
            vehicle.Categories = _vehicleCategoryApplication.GetVehicleCategories();
            return Partial("Edit", vehicle);
        }

        public JsonResult OnPostEdit(EditVehicle command)
        {
            if (ModelState.IsValid)
            {
            }

            var result = _vehicleApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetAvailable(int id)
        {
            var result = _vehicleApplication.IsAvailable(id);
            if (result.IsSuccedded)
            {
                TempData["Success"] = "Successfully!";
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }

        public IActionResult OnGetNotAvailable(int id)
        {
            var result = _vehicleApplication.IsNotAvailable(id);
            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}