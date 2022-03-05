using _0_Framework.App;
using _0_Framework.Infrastucture;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.App.Role
{
    public class CreateRole
    {
        public string Name { get; set; }

        public List<byte> Permissions { get; set; } 
    }

}
