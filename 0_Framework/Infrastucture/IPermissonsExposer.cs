using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrastucture
{
    public interface IPermissonsExposer
    {
        Dictionary<string, List<PermissionDto>> Expose();
    }
}
