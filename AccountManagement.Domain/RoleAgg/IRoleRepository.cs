using _0_Framework.Domain;
using AccountManagement.App.Role;
using System.Collections.Generic;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<int , Role>
    {
        EditRole GetDetails(int Id);
        List<RoleViewModel> ListOfRoles();
    }
}
