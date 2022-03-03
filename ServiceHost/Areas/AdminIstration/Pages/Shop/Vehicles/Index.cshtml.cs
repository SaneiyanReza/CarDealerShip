using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ShopManegement.App.Vehicle;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManegement.App.VehicleCategories;
using DiscountManagement.App.CustomerDiscount;
using Microsoft.AspNetCore.Authorization;
using _0_Framework.Infrastucture;

namespace ServiceHost.Areas.Administration.Pages.Shop.Vehicle
{
    [Authorize(Roles = RolesAccess.Admin)]
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
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
            _vehicleApplication.IsAvailable(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetNotAvailable(int id)
        {
            _vehicleApplication.IsNotAvailable(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetDeleted(int id)
        {
            var customerId = _vehicleApplication.DeleteByID(id);
            if (customerId.IsSuccedded)
            {
                Message = "خودرو با موفقیت حذف شد!";
                return RedirectToPage("./Index");
            }
            //_vehicleApplication.DeleteByID(id);
            return RedirectToPage("./Index");
        }
    }
}