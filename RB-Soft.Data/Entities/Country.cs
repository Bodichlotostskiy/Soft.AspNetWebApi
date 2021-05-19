using System.ComponentModel.DataAnnotations;

namespace RB_Soft.Data.Entities
{
    public class Country
    {
        [Key]
        public string Name { get; set; }
    }
}
