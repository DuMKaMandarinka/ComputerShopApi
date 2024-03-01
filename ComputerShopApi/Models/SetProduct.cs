using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopApi.Models
{
    public class SetProduct:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public List<Device> Devices { get; set; }

        //public virtual ICollection<Device> Products { get; set; }

        //public virtual List<Info> Info { get; set; }
    }
}
