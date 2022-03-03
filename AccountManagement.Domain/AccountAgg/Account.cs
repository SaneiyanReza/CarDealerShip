using _0_Framework.Domain;
using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : BaseEntity<int>
    {
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public int RoleID { get; private set; }
        public string Mobile { get; private set; }
        public string ProfilePhoto { get; private set; }
        public Role Role { get; private set; }
        public Account(string fullName, string userName, string password,
            int roleID, string mobile, string profilePhoto)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            RoleID = roleID;
            Mobile = mobile;
            ProfilePhoto = profilePhoto;
        }

        public void Edit(string fullName, string userName,
            int roleID, string mobile, string profilePhoto)
        {
            FullName = fullName;
            UserName = userName;
            RoleID = roleID;
            Mobile = mobile;
            if (!string.IsNullOrWhiteSpace(profilePhoto))
            {
                ProfilePhoto = profilePhoto;
            }
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

    }
}
