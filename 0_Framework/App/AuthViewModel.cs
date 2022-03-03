namespace _0_Framework.App
{
    public class AuthViewModel
    {
        public int AccountID { get; set; }
        public int RoleID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public AuthViewModel(int accountID, int roleID, string userName, string fullName)
        {
            AccountID = accountID;
            RoleID = roleID;
            UserName = userName;
            FullName = fullName;
        }

    }
}