using ComputerShopApi.Models;

namespace ComputerShopApi.Response
{
    public class SalesResponse
    {
        public int UserId { get; set; }

        public int BranchId { get; set; } 

        public DateTime DateTime { get; set; }
        public int ProductId { get; set; }
    }
}
