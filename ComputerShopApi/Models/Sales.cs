using System.Reflection.Metadata;

namespace ComputerShopApi.Models
{
    public class Sales:BaseEntity
    {
        public int UserId { get; set; }

        public int BranchId { get; set; }

        public DateTime DateTime { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
