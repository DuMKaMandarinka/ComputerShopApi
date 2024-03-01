namespace ComputerShopApi.Models
{
    public class Address:BaseEntity
    {
        public string City { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public int Apartment { get; set; }

        public int BranchId { get; set; }

        public Branch Branch { get; set; }
    }
}
