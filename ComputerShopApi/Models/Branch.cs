using Microsoft.Extensions.Hosting;

namespace ComputerShopApi.Models
{
    public class Branch: BaseEntity
    {
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        //адрес потом
        //public Address? Address { get; set; }
    }
}
