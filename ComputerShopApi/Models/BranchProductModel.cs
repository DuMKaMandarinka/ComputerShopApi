using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopApi.Models
{
    public class BranchProductModel
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public int ProductId { get; set; }
        
        public int BranchId { get; set; }
       
        public Branch Branch { get; set; }
        public Product Product { get; set; } 



    }
}
