using Food.IService.IngredientHandlers.Models;

namespace Food.IService.IngredientHandlers.Queries
{
    public class GetIngredientByIdQuery : IQuery<IngredientDto>
    {
        public GetIngredientByIdQuery(int ingredientId)
        {
            IngredientId = ingredientId;
        }

        public int IngredientId { get; }
    }
}
