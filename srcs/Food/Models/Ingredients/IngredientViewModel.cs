using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.DataTypes;
using Common.EnumDataTypes;

namespace Food.Models.Ingredients
{
    public class IngredientViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IngredientQuantityViewModel IngredientQuantity { get; set; }
    }

    public class IngredientQuantityViewModel
    {
        public decimal Quantity { get; set; }
        public QuantityType QuantityType { get; set; }

        public override string ToString()
        {
            return $"{Quantity}{QuantityType}";
        }
    }
}
