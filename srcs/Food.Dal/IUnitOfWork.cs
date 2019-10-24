using Food.Dal.Repositories;

namespace Food.Dal
{
    public interface IUnitOfWork
    {
        IIngredientRepository IngredientRepository { get; }
        IRecipeRepository RecipeRepository { get; }

        int SaveChanges();
    }
}
