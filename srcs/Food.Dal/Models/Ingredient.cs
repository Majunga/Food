using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.EnumDataTypes;

namespace Food.Dal.Models
{
    public class Ingredient : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal MetricQuantity { get; set; }

        [Required]
        public QuantityType QuantityType { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
