using Common.DataTypes;

namespace Food.IService.IngredientHandlers.Command
{
    public class CreateIngredientCommand
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public IngredientQuantity  Quantity { get; set; }
    }
}
