using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ShopManegement.App.Vehicle;
using Microsoft.AspNetCore.Mvc.Rendering;
using DiscountManagement.App.ColleagueDiscount;

namespace ServiceHost.Areas.Administration.Pages.Discount.ColleagueDiscount
{
    //[Authorize(Roles = "1, 3")]
    public class IndexModel : PageModel
    {
        public ColleagueDiscountSearchModel SearchModel;
        public List<ColleagueDiscountViewModel> ColleagueDiscounts;
        public SelectList Vehicles;

        private readonly IVehicleApplication _vehicleApplication;
        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;
        public IndexModel(IVehicleApplication productApplication, IColleagueDiscountApplication colleagueDiscountApplication)
        {
            _vehicleApplication = productApplication;
            _colleagueDiscountApplication = colleagueDiscountApplication;
        }

        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            Vehicles = new SelectList(_vehicleApplication.GetVehicles(), "ID", "Specifications");
            ColleagueDiscounts = _colleagueDiscountApplication.Search(searchModel);
            foreach (var item in ColleagueDiscounts)
            {
                if (item.Vehicle == null)
                {
                    _colleagueDiscountApplication.DeleteByID(item.ID);
                }
            }
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineColleagueDiscount
            {
                Vehicles = _vehicleApplication.GetVehicles()
            };

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(DefineColleagueDiscount command)
        {
            var result = _colleagueDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var colleagueDiscount = _colleagueDiscountApplication.GetDetails(id);
            colleagueDiscount.Vehicles = _vehicleApplication.GetVehicles();

            return Partial("Edit", colleagueDiscount);
        }

        public JsonResult OnPostEdit(EditColleagueDiscount command)
        {
            if (ModelState.IsValid)
            {
            }

            var result = _colleagueDiscountApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(int id)
        {
            _colleagueDiscountApplication.Romove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(int id)
        {
            _colleagueDiscountApplication.Restore(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetDeleted(int id)
        {
            _vehicleApplication.DeleteByID(id);
            return RedirectToPage("./Index");
        }
    }
}