using Food.IService.RecipeHandlers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Food.Service.Tests.RecipeHandlers
{
    public class RecipeDataProvider
    {
        public CreateRecipeCommand CreateCommand(string name = null, string description = null)
        {
            return new CreateRecipeCommand{
                Name = name ?? Guid.NewGuid().ToString(),
                Description = description
            };
        }
    }
}
