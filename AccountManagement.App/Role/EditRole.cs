using _0_Framework.Infrastucture;
using System.Collections.Generic;

namespace AccountManagement.App.Role
{
    public class EditRole : CreateRole
    {
        public int ID { get; set; }
        public List<PermissionDto> MappedPermissions { get; set; }
    }

}
