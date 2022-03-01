using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ShopManegement.App.Vehicle;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManegement.App.VehicleCategories;
using DiscountManagement.App.CustomerDiscount;

namespace ServiceHost.Areas.Administration.Pages.Discount.CustomerDiscount
{
    //[Authorize(Roles = "1, 3")]
    public class IndexModel : PageModel
    {
        public CustomerDiscountSearchModel SearchModel;
        public List<CustomerDiscountViewModel> CustomerDiscounts;
        public SelectList Vehicles;

        private readonly IVehicleApplication _vehicleApplication;
        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        public IndexModel(IVehicleApplication productApplication, ICustomerDiscountApplication customerDiscountApplication)
        {
            _vehicleApplication = productApplication;
            _customerDiscountApplication = customerDiscountApplication;
        }

        public void OnGet(CustomerDiscountSearchModel searchModel , CustomerDiscountViewModel model)
        {
            
            Vehicles = new SelectList(_vehicleApplication.GetVehicles(), "ID", "Specifications");
            CustomerDiscounts = _customerDiscountApplication.Search(searchModel);
            foreach (var item in CustomerDiscounts)
            {
                if (item.Vehicle == null)
                {
                    _customerDiscountApplication.DeleteByID(item.ID);
                }
            }
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineCustomerDiscount
            {
                Vehicles = _vehicleApplication.GetVehicles()
            };

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var customerDiscount = _customerDiscountApplication.GetDetails(id);
            customerDiscount.Vehicles = _vehicleApplication.GetVehicles();

            return Partial("Edit", customerDiscount);
        }

        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}