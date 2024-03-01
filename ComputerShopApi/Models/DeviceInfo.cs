using System.Reflection.Metadata;

namespace ComputerShopApi.Models
{
    public class DeviceInfo: BaseEntity
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public int DeviceId { get; set; }

        public Device Device { get; set; } = null!;
    }
}
