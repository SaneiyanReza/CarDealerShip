using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ShopManegement.App.Vehicle;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManegement.App.VehiclePicture;

namespace ServiceHost.Areas.Administration.Pages.Shop.VehiclePictures
{
    public class IndexModel : PageModel
    {
        public VehiclePictureSearchModel SearchModel;
        public List<VehiclePictureViewModel> VehiclePicture;
        public SelectList Vehicles;
        public SelectList VehiclesModel;
        public SelectList VehiclesCreationDate;

        private readonly IVehicleApplication _vehicleApplication;
        private readonly IVehiclePictureApplication _vehiclePictureApplication;

        public IndexModel(IVehicleApplication productApplication , IVehiclePictureApplication vehiclePictureApplication )
        {
            _vehicleApplication = productApplication;
            _vehiclePictureApplication = vehiclePictureApplication;
        }

        public void OnGet(VehiclePictureSearchModel searchModel)
        {
            Vehicles = new SelectList(_vehicleApplication.GetVehicles(), "ID", "Name");
            VehiclesModel = new SelectList(_vehicleApplication.GetVehicles(), "ID", "Model");
            VehiclesCreationDate = new SelectList(_vehicleApplication.GetVehicles(), "ID", "CreationDate");
            VehiclePicture = _vehiclePictureApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateVehiclePicture
            {
                Vehicles = _vehicleApplication.GetVehicles()
            };

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateVehiclePicture command)
        {
            var result = _vehiclePictureApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var vehiclePicture = _vehiclePictureApplication.GetDetails(id);
            vehiclePicture.Vehicles = _vehicleApplication.GetVehicles();
            return Partial("Edit", vehiclePicture);
        }

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
                TempData["Success"] = "Successfully!";
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