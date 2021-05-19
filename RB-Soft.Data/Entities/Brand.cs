using System.ComponentModel.DataAnnotations;

namespace RB_Soft.Data.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
