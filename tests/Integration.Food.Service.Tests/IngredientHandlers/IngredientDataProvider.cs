using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;
using Common.EnumDataTypes;
using Food.IService.IngredientHandlers.Commands;

namespace Integration.Food.Service.Tests.IngredientHandlers
{
    public class IngredientDataProvider
    {
        public CreateIngredientCommand CreateCommand(string name = null, decimal quantity = 10m,
            QuantityType quantityType = QuantityType.Gram)
        {
            return new CreateIngredientCommand
            {
                Name = name ?? Guid.NewGuid().ToString(),
                Quantity = new IngredientQuantity(quantityType, quantity)
            };
        }
    }
}
