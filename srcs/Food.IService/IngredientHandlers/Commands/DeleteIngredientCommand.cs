using System;
using System.Collections.Generic;
using System.Text;

namespace Food.IService.IngredientHandlers.Commands
{
    public class DeleteIngredientCommand
    {
        public DeleteIngredientCommand(int ingredientId)
        {
            IngredientId = ingredientId;
        }

        public int IngredientId { get; }
    }
}
