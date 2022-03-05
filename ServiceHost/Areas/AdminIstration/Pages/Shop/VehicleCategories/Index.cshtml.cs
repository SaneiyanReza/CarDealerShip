using _0_Framework.Infrastucture;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManegement.App.VehicleCategories;
using ShopManegment.Configuration.Permissions;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.VehicleCategories
{
    public class IndexModel : PageModel
    {
        public SearchVehicleCategory SearchModel;
        public List<VehicleCategoryViewModel> VehicleCategories;

        private readonly IVehicleCategoryApplication _vehicleCategoryApplication;

        public IndexModel(IVehicleCategoryApplication productCategoryApplication)
        {
            _vehicleCategoryApplication = productCategoryApplication;
        }

        [NeedsPermission(ShopPermissions.ListVehicleCategories)]
        public void OnGet(SearchVehicleCategory searchModel)
        {
            VehicleCategories = _vehicleCategoryApplication.Search(searchModel);
        }

        [NeedsPermission(ShopPermissions.CreateVehicleCategorie)]
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateVehicleCategory());
        }

        [NeedsPermission(ShopPermissions.CreateVehicleCategorie)]
        public JsonResult OnPostCreate(CreateVehicleCategory command)
        {
            var result = _vehicleCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        [NeedsPermission(ShopPermissions.EditVehicleCategorie)]
        public IActionResult OnGetEdit(int id)
        {
            var vehicleCategory = _vehicleCategoryApplication.GetDetail(id);
            return Partial("Edit", vehicleCategory);
        }

        [NeedsPermission(ShopPermissions.EditVehicleCategorie)]
        public JsonResult OnPostEdit(EditVehicleCategory command)
        {
            if (ModelState.IsValid)
            {
            }

            var result = _vehicleCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(int id)
        {
            var result = _vehicleCategoryApplication.Remove(id);
            if (result.IsSuccedded)
            {
                TempData["Success"] = "Successfully!";
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(int id)
        {
            var result = _vehicleCategoryApplication.Restore(id);
            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}