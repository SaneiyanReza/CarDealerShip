using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ShopManegement.App.Vehicle;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManegement.App.VehiclePicture;
using _0_Framework.Infrastucture;
using ShopManegment.Configuration.Permissions;

namespace ServiceHost.Areas.Administration.Pages.Shop.VehiclePictures
{
    public class IndexModel : PageModel
    {
        public VehiclePictureSearchModel SearchModel;
        public List<VehiclePictureViewModel> VehiclePictures;
        public SelectList Vehicles;

        //[TempData]
        //public string FormResult { get; set; }


        private readonly IVehicleApplication _vehicleApplication;
        private readonly IVehiclePictureApplication _vehiclePictureApplication;

        public IndexModel(IVehicleApplication productApplication , IVehiclePictureApplication vehiclePictureApplication )
        {
            _vehicleApplication = productApplication;
            _vehiclePictureApplication = vehiclePictureApplication;
        }

        [NeedsPermission(ShopPermissions.ListVehiclePictures)]
        public void OnGet(VehiclePictureSearchModel searchModel)
        {
            Vehicles = new SelectList(_vehicleApplication.GetVehicles(), "ID", "Specifications");
            VehiclePictures = _vehiclePictureApplication.Search(searchModel);
        }

        [NeedsPermission(ShopPermissions.CreateVehiclePicture)]
        public IActionResult OnGetCreate()
        {
            var command = new CreateVehiclePicture
            {
                Vehicles = _vehicleApplication.GetVehicles()
            };

            return Partial("./Create", command);
        }

        [NeedsPermission(ShopPermissions.CreateVehiclePicture)]
        public JsonResult OnPostCreate(CreateVehiclePicture command)
        {
            var result = _vehiclePictureApplication.Create(command);
            return new JsonResult(result);
        }

        [NeedsPermission(ShopPermissions.EditVehiclePicture)]
        public IActionResult OnGetEdit(int id)
        {
            var vehiclePicture = _vehiclePictureApplication.GetDetails(id);
            vehiclePicture.Vehicles = _vehicleApplication.GetVehicles();
            return Partial("Edit", vehiclePicture);
        }

        [NeedsPermission(ShopPermissions.EditVehiclePicture)]
        public JsonResult OnPostEdit(EditVehiclePicture command)
        {
            if (ModelState.IsValid)
            {
            }

            var result = _vehiclePictureApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(int id)
        {
            var result = _vehiclePictureApplication.Remove(id);
            if (result.IsSuccedded)
            {
                //FormResult = "Successfully!";
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(int id)
        {
            var result = _vehiclePictureApplication.Restore(id);
            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}