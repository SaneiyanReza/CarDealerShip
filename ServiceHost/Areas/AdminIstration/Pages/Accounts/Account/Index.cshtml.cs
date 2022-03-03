using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using AccountManagement.App.Account;
using AccountManagement.App.Role;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Account
{
    //[Authorize(Roles = "1, 3")]
    public class IndexModel : PageModel
    {
        public AccountSearchModel SearchModel;
        public List<AccountViewModel> Accounts;
        public SelectList Roles;

        private readonly IAccountApplication _accountApplication;
        private readonly IRoleApplication _roleApplication;

        public IndexModel(IAccountApplication accountApplication , IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
        }

        public void OnGet(AccountSearchModel searchModel)
        {
            Roles = new SelectList(_roleApplication.ListOfRoles(), "ID", "Name");
            Accounts = _accountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateAccount
            {
                Roles = _roleApplication.ListOfRoles()
            };

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateAccount command)
        {
            var result = _accountApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var account = _accountApplication.GetDetails(id);
            account.Roles = _roleApplication.ListOfRoles();
            return Partial("Edit", account);
        }

        public JsonResult OnPostEdit(EditAccount command)
        {
            var result = _accountApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetChangePassword(int id)
        {
            var accountPassword = new ChangePassword { ID = id };
            return Partial("ChangePassword", accountPassword);
        }

        public JsonResult OnPostChangePassword(ChangePassword command)
        {
            var result = _accountApplication.ChangePassword(command);
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