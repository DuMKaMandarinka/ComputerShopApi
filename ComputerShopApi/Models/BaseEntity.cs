using System.ComponentModel.DataAnnotations;

namespace ComputerShopApi.Models
{
    public class BaseEntity
    {
        [Key, Required]
        public int Id { get; set; }

        //public DateTime? DateAdded { get; set; }

        //public DateTime? DateUpdated { get; set; }
    }
}
