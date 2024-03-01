using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace ComputerShopApi.Models
{
    public class Device: BaseEntity
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public List<SetProduct> SetProducts { get; set; }

        //public int BrandId { get; set; }

        //public Brand Brand { get; set; }

        public int TypeId { get; set; }

        public Type Type { get; set; } = null!;

        public ICollection<DeviceInfo> Info { get; } = new List<DeviceInfo>();
    }
}
