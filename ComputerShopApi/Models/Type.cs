using Microsoft.Extensions.Hosting;

namespace ComputerShopApi.Models
{
    public class Type : BaseEntity
    {
        public string Name { get; set; }

        //public List<Brand> Brands { get; } = new();

        public ICollection<Device> Devices { get; } = new List<Device>();
    }
}
