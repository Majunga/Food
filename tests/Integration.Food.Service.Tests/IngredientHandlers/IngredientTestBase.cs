using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Integration.Food.Service.Tests.IngredientHandlers
{
    public class IngredientTestBase : ServiceTestBase
    {
        public IngredientTestBase(ITestOutputHelper output) : base(output)
        {
            this.IngredientDataProvider = new IngredientDataProvider();
        }

        public IngredientDataProvider IngredientDataProvider { get; }
    }
}
