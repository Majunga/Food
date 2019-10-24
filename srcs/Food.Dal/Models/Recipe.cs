using System.ComponentModel.DataAnnotations;

namespace Food.Dal.Models
{
    public class Recipe : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
