using ComputerShopApi.Models;

namespace ComputerShopApi.Response
{
    public class SetProductResponse:BaseEntity
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public List<Device> Сompound { get; set; }
    }
}
