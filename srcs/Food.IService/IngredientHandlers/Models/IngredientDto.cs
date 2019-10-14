using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Food.IService.IngredientHandlers.Models
{
    public class IngredientDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IngredientQuantity Quantity { get; set; }
    }
}
