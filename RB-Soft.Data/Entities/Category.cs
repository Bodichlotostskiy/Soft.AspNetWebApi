using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RB_Soft.Data.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Detail> Details { get; set; }
    }
}
