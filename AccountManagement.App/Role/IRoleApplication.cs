using _0_Framework.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.App.Role
{
    public interface IRoleApplication
    {
        OperationResult Create(CreateRole createRole);
        OperationResult Edit(EditRole editRole);
        EditRole GetDetails(int Id);
        List<RoleViewModel> ListOfRoles();
    }
}
