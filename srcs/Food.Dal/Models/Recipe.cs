using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Food.Dal.Models
{
    public class Recipe : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
