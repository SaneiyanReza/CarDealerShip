namespace _0_Framework.Infrastucture
{
    public class PermissionDto
    {
        public byte Code { get; set; }
        public string Name { get; set; }

        public PermissionDto(byte code, string name)
        {
            Code = code;
            Name = name;
        }

    }
}
