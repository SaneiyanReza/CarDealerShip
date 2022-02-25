using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ShopManegement.App.Vehicle;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManegement.App.VehicleCategories;
using ShopManegement.App.VehiclePicture;
using ShopManegement.App.Slide;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    //[Authorize(Roles = "1, 3")]
    public class IndexModel : PageModel
    {
        public List<SlideViewModel> Slides;

        private readonly ISlideApplication _slideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet()
        {
            Slides = _slideApplication.GetList();
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateSlide();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateSlide command)
        {
            var result = _slideApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var slide = _slideApplication.GetDetails(id);
            return Partial("Edit", slide);
        }

        public JsonResult OnPostEdit(EditSlide command)
        {
            if (ModelState.IsValid)
            {
            }

            var result = _slideApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(int id)
        {
            var result = _slideApplication.Remove(id);
            if (result.IsSuccedded)
            {
                TempData["Success"] = "Successfully!";
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(int id)
        {
            var result = _slideApplication.Restore(id);
            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}