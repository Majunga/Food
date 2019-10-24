using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Food.Dal.Models
{
    public class Ingredient : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
