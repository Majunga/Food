using Food.IService.RecipeHandlers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food.IService.RecipeHandlers.Queries
{
    public class GetAllRecipesQuery : IQuery<IReadOnlyCollection<RecipeDto>>
    {
    }
}
