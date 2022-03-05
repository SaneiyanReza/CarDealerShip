namespace AccountManagement.Domain.RoleAgg
{
    public class Permission
    {
        public int ID { get; private set; }
        public byte Code { get; private set; }
        public string Name { get; private set; }
        public int RoleID { get; private set; }
        public Role Role { get; private set; }
        public Permission(byte code)
        {
            Code = code;
        }
        public Permission(byte code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
