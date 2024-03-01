using System.Reflection.Metadata;

namespace ComputerShopApi.Models
{
    public class PromotionProduct
    {
        public int Id { get; set; }

        public int PromotionShare { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateEnded { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;
    }
}
