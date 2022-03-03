using _0_Framework.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.App.Account
{
    public interface IAccountApplication
    {
        OperationResult Create(CreateAccount model);
        OperationResult Edit(EditAccount model);
        OperationResult ChangePassword(ChangePassword model);
        OperationResult Login(Login login);
        EditAccount GetDetails(int id);
        List<AccountViewModel> Search(AccountSearchModel model);
        void Logout();
        //string GetPhoto(string photo);
    }
}
