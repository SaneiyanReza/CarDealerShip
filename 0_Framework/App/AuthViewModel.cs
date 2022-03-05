using System.Collections.Generic;

namespace _0_Framework.App
{
    public class AuthViewModel
    {
        public int AccountID { get; set; }
        public int RoleID { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string ProfilePhoto { get; set; }
        public List<byte> Permissions { get; set; }
        public AuthViewModel(int accountID, int roleID, string userName, string fullName , string profilePhoto , List<byte> permissions)
        {
            AccountID = accountID;
            RoleID = roleID;
            UserName = userName;
            FullName = fullName;
            ProfilePhoto = profilePhoto;
            Permissions = permissions;
        }

        public AuthViewModel()
        {
        }
    }
}