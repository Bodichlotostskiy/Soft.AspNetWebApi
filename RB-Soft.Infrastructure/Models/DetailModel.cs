using System.ComponentModel.DataAnnotations;

namespace RB_Soft.Infrastructure.Models
{
    public class DetailModel
    {
        public int DetailId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Material { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
