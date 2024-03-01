using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ComputerShopApi.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }

        //[Column("Photo")]
        //public string FilePath { get; set; }

        public int Price { get; set; }

        public string Type { get; set; }

        public SetProduct SetProduct { get; set; }

        public Device Device { get; set; }   

        public AmountSales? AmountSales { get; set; }

        public List<Branch> Branches { get; set; } = new List<Branch>();

        public List<Sales> Sales { get; } = new List<Sales>();

        //public ICollection<PriceHistory> Price { get; } = new List<PriceHistory>();

        //public PromotionProduct? PromotionProduct { get; set; }
    }
}
