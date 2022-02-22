using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManegement.App.VehicleCategories;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.VehicleCategories
{
    //[Authorize(Roles = "1, 3")]
    public class IndexModel : PageModel
    {
        public SearchVehicleCategory SearchModel;
        public List<VehicleCategoryViewModel> VehicleCategories;

        private readonly IVehicleCategoryApplication _vehicleCategoryApplication;

        public IndexModel(IVehicleCategoryApplication productCategoryApplication)
        {
            _vehicleCategoryApplication = productCategoryApplication;
        }

        public void OnGet(SearchVehicleCategory searchModel)
        {
            VehicleCategories = _vehicleCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateVehicleCategory());
        }

        public JsonResult OnPostCreate(CreateVehicleCategory command)
        {
            var result = _vehicleCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var vehicleCategory = _vehicleCategoryApplication.GetDetail(id);
            return Partial("Edit", vehicleCategory);
        }

        public JsonResult OnPostEdit(EditVehicleCategory command)
        {
            if (ModelState.IsValid)
            {
            }

            var result = _vehicleCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}