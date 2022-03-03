using _0_Framework.Domain;
using AccountManagement.Domain.AccountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role : BaseEntity<int>
    {
        public string Name { get; private set; }
        public List<Account> Accounts { get; private set; }
        public Role(string name)
        {
            Name = name;
        }
        public void Edit(string name)
        {
            Name = name;
        }
    }
}
