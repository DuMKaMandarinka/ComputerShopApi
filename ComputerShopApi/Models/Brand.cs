namespace ComputerShopApi.Models
{
    public class Brand:BaseEntity
    {
        public string Name { get; set; }

        public List<Type> Types { get; } = new();

        public List<Device> Devices { get; } = new List<Device>();
    }
}
