using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using AccountManagement.App.Account;
using AccountManagement.App.Role;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Role
{
    //[Authorize(Roles = "1, 3")]
    public class IndexModel : PageModel
    {
        public List<RoleViewModel> Roles;

        private readonly IRoleApplication _roleApplication;
        public IndexModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        public void OnGet()
        {
            Roles = _roleApplication.ListOfRoles();
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateRole();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateRole command)
        {
            var result = _roleApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var role = _roleApplication.GetDetails(id);
            return Partial("Edit", role);
        }

        public JsonResult OnPostEdit(EditRole command)
        {
            if (ModelState.IsValid)
            {
            }

            var result = _roleApplication.Edit(command);
            return new JsonResult(result);
        }

        //public IActionResult OnGetDeleted(int id)
        //{
        //    //var customerId = _customerDiscountApplication.DeleteByID()
        //    _accountApplication.DeleteByID(id);
        //    return RedirectToPage("./Index");
        //}
    }
}