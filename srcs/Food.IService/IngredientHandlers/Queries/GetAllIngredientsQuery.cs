using System;
using System.Collections.Generic;
using System.Text;
using Food.IService.IngredientHandlers.Models;

namespace Food.IService.IngredientHandlers.Queries
{
    public class GetAllIngredientsQuery : IQuery<IReadOnlyCollection<IngredientDto>>
    {
    }
}
