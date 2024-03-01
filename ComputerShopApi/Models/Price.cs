
using Microsoft.Extensions.Hosting;

namespace ComputerShopApi.Models
{
    public class PriceHistory
    {
        public int Id { get; set; }

        public int Price { get; set; }

        public DateTime DateAdded { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
