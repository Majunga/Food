using System.Collections.Generic;
using Food.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Food.Dal.Repositories
{
    public interface IIngredientRepository
    {
        void Create(Ingredient entity);
        IReadOnlyCollection<Ingredient> Read();
        Ingredient Read(int id);
        void Update(Ingredient entity);
        void Delete(int id);
    }

    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(DbContext context) : base(context)
        {
        }
    }
}
