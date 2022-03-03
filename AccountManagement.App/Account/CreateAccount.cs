using _0_Framework.App;
using AccountManagement.App.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.App.Account
{
    public class CreateAccount
    {
        [Required(ErrorMessage = Validations.IsRequired)]
        public string FullName { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string UserName { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string Password { get; set; }

        public int RoleID { get; set; }

        [Required(ErrorMessage = Validations.IsRequired)]
        public string Mobile { get; set; }

        public string ProfilePhoto { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
