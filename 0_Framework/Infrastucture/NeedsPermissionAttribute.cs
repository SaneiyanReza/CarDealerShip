using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrastucture
{
    public class NeedsPermissionAttribute : Attribute
    {
        public byte Permission { get; set; }

        public NeedsPermissionAttribute(byte permission)
        {
            Permission = permission;
        }
    }
}
