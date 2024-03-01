namespace ComputerShopApi.Models
{
    public class AmountSales:BaseEntity
    {
        public int Amount { get; set;}

        public int Product_Id { get; set;}

        public Product Product { get; set;} = null!;
    }
}
