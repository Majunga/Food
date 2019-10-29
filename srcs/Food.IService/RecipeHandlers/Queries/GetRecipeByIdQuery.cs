using Food.IService.RecipeHandlers.Models;

namespace Food.IService.RecipeHandlers.Queries
{
    public class GetRecipeByIdQuery : IQuery<RecipeDto>
    {
        public GetRecipeByIdQuery(int recipeId)
        {
            RecipeId = recipeId;
        }

        public int RecipeId { get; }
    }
}
