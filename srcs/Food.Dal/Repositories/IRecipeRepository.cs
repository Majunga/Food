using Food.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Food.Dal.Repositories
{
    public interface IRecipeRepository
    {
        void Create(Recipe entity);
        IReadOnlyCollection<Recipe> Read();
        Recipe Read(int id);
        void Update(Recipe entity);
        void Delete(int id);
    }

    public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DbContext context) : base(context)
        {
        }
    }
}
