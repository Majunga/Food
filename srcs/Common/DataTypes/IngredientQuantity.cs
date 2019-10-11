using Common.EnumDataTypes;

namespace Common.DataTypes
{
    public class IngredientQuantity
    {
        public QuantityType QuantityType { get; }
        public decimal Quantity { get; }

        public IngredientQuantity(QuantityType quantityType, in decimal quantity)
        {
            QuantityType = quantityType;
            Quantity = quantity;
        }
    }
}
