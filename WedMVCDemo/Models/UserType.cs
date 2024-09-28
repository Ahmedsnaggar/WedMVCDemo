namespace WedMVCDemo.Models
{
    public class UserType
    {
        public int Id { get; set; }
        public string UType { get; set; }
        public string MyPropertyId { get; set; }
        public AppUser? MyProperty { get; set; }
    }
}
