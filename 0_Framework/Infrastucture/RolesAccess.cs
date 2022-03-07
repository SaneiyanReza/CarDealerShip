using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrastucture
{
    public static class RolesAccess
    {
        public const string Admin = "1";
        public const string SysUser = "2";
        public const string Content = "3";

        public static string GetRoleByID(int id)
        {
            return id switch
            {
                1 => "مدیر سیستم",
                3 => "دستیار مدیر سیستم",
                _ => null,
            };
        }
    }
}
