using _0_Framework.Domain;
using AccountManagement.App.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<int , Account>
    {
        EditAccount GetDetails(int id);
        List<AccountViewModel> Search(AccountSearchModel model);
        Account GetByUserName(string userName);
    }
}
