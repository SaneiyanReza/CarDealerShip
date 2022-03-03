using _0_Framework.App;
using _0_Framework.Infrastucture;
using AccountManagement.App.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagement.Infrastructure.EfCore.Repository
{
    public class AccountRepository : RepositoryBase<int, Account>, IAccountRepository
    {
        private readonly AccountContext _accountContext;
        public AccountRepository(AccountContext accountContext) : base(accountContext)
        {
            _accountContext = accountContext;
        }

        public Account GetByUserName(string userName)
        {
            return _accountContext.Accounts.FirstOrDefault(x => x.UserName == userName);
        }

        public EditAccount GetDetails(int id)
        {
            return _accountContext.Accounts.Select(x => new EditAccount
            {
                ID = x.ID,
                FullName = x.FullName,
                Mobile = x.Mobile,
                RoleID = x.RoleID,
                UserName = x.UserName
            }).FirstOrDefault(x => x.ID == id);
        }

        public List<AccountViewModel> Search(AccountSearchModel model)
        {
            var query = _accountContext.Accounts.Include(x => x.Role).Select(x => new AccountViewModel
            {
                ID = x.ID,
                FullName = x.FullName,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                RoleID = x.RoleID,
                Role = x.Role.Name,
                UserName = x.UserName,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(model.FullName))
            {
                query = query.Where(x => x.FullName.Contains(model.FullName));
            }
            if (!string.IsNullOrWhiteSpace(model.UserName))
            {
                query = query.Where(x => x.UserName.Contains(model.UserName));
            }
            if (!string.IsNullOrWhiteSpace(model.Mobile))
            {
                query = query.Where(x => x.Mobile.Contains(model.Mobile));
            }
            if (model.RoleID > 0)
            {
                query = query.Where(x => x.RoleID == model.RoleID);
            }

            return query.OrderByDescending(x => x.ID).ToList();
        }
    }
}
