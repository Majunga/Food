using Common.EnumDataTypes;

namespace Common.DataTypes
{
    public class IngredientQuantity
    {
        public IngredientQuantity(QuantityType quantityType, in decimal quantity)
        {
            QuantityType = quantityType;
            Quantity = quantity;
        }

        public decimal Quantity { get; }
        public QuantityType QuantityType { get; }

        public override string ToString()
        {
            return $"{Quantity}{QuantityType}";
        }
    }
}
