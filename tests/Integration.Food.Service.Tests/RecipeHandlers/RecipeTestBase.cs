using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Integration.Food.Service.Tests.RecipeHandlers
{
    public class RecipeTestBase : ServiceTestBase
    {
        public RecipeTestBase(ITestOutputHelper output) : base(output)
        {
            this.RecipeDataProvider = new RecipeDataProvider();
        }

        public RecipeDataProvider RecipeDataProvider { get; }
    }
}
