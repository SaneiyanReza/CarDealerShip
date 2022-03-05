using System.Collections.Generic;
using System.Linq;
using _0_Framework.Infrastucture;
using AccountManagement.App.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Role
{
    public class EditModel : PageModel
    {
        public EditRole Command;
        public List<SelectListItem> Permissions = new();
        private readonly IRoleApplication _roleApplication;
        private readonly IEnumerable<IPermissonsExposer> _exposers;

        public EditModel(IRoleApplication roleApplication , IEnumerable<IPermissonsExposer> exposers)
        {
            _roleApplication = roleApplication;
            _exposers = exposers;
        }

        public void OnGet(int id)
        {
            Command = _roleApplication.GetDetails(id);
            foreach (var exposer in _exposers)
            {
                var exposedPermissions = exposer.Expose();
                foreach (var (key, value) in exposedPermissions)
                {
                    var group = new SelectListGroup { Name = key };
                    foreach (var permission in value)
                    {
                        var item = new SelectListItem(permission.Name, permission.Code.ToString())
                        {
                            Group = group
                        };

                        if (Command.MappedPermissions.Any(x => x.Code == permission.Code))
                            item.Selected = true;

                        Permissions.Add(item);
                    }
                }
            }
        }

        public IActionResult OnPost(EditRole command)
        {
            _roleApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}