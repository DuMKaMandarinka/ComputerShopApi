using ComputerShopApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopApi.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }

        //public IFormFile FormFile { get; set; }

        //public int? BrandId { get; set; }

        public int Price { get; set; }

        public int? TypeId { get; set; }

        public List<int>? DevicesId { get; set; }

    }
}
