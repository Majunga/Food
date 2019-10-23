using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Common.DataTypes;
using Common.EnumDataTypes;

namespace Food.IService.IngredientHandlers.Commands
{
    public class CreateIngredientCommand
    {
        public string Name { get; set; }

        public int? Id { get; set; }
    }
}
