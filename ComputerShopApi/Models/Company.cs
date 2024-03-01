namespace ComputerShopApi.Models
{
    public class Company:BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Branch> Branch { get; } = new List<Branch>();
    }
}
