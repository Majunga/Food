using Common.EnumDataTypes;

namespace Food.Models.Ingredients
{
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
