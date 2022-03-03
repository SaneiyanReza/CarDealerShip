using _0_Framework.App;
using _0_Framework.Infrastucture;
using AccountManagement.App.Role;
using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagement.Infrastructure.EfCore.Repository
{
    public class RoleRepository : RepositoryBase<int, Role>, IRoleRepository
    {
        private readonly AccountContext _accountContext;

        public RoleRepository(AccountContext accountContext) : base(accountContext)
        {
            _accountContext = accountContext;
        }

        public EditRole GetDetails(int Id)
        {
            return _accountContext.Roles.Select(x => new EditRole
            {
                ID = x.ID,
                Name = x.Name
            }).FirstOrDefault(x => x.ID == Id);
        }

        public List<RoleViewModel> ListOfRoles()
        {
            return _accountContext.Roles.Select(x => new RoleViewModel
            {
                ID = x.ID,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi()
            }).ToList();
        }
    }
}
