namespace Food.IService.RecipeHandlers.Commands
{
    public class DeleteRecipeCommand
    {
        public DeleteRecipeCommand(int recipeId)
        {
            RecipeId = recipeId;
        }

        public int RecipeId { get; }
    }
}
