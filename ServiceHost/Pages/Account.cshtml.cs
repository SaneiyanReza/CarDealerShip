using AccountManagement.App.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        [TempData]
        public string LoginMessage { get; set; }
        [TempData]
        public string RegisterMessage { get; set; }

        private readonly IAccountApplication _accountApplication;

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(Login login)
        {
            var result =_accountApplication.Login(login);
            if (result.IsSuccedded)
            {
                return RedirectToPage("/Index");
            }

            LoginMessage = result.Message;
            return RedirectToPage("/Account");
        }

        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Account");
        }

        public IActionResult OnPostRegister(CreateAccount account)
        {
            if (account.Password == null)
            {
                RegisterMessage = "خطا!";
                return RedirectToPage("/Account");
            }
            var result = _accountApplication.Create(account);
            if (result.IsSuccedded)
            {
                return RedirectToPage("/Account");
            }
            RegisterMessage = result.Message;
            return RedirectToPage("/Account");
        }
    }
}
