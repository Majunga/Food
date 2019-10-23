using System;
using Food.IService.IngredientHandlers.Commands;

namespace Integration.Food.Service.Tests.IngredientHandlers
{
    public class IngredientDataProvider
    {
        public CreateIngredientCommand CreateCommand(string name = null)
        {
            return new CreateIngredientCommand
            {
                Name = name ?? Guid.NewGuid().ToString(),
            };
        }
    }
}
