using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Dal.Models
{
    public class RecipeIngredient : Entity
    {
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
