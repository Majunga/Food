using FluentAssertions;
using Food.Dal.Models;
using Food.IService.RecipeHandlers.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Unit.Food.Service.Tests.RecipeHandlers.Queries
{
    public class GetAllRecipesQueryHandlerTests : ServiceTestBase
    {
        [Fact]
        public void NoRecipes_ShouldReturnEmpty()
        {
            // arrange
            this.MockRecipeRepository.Setup(m => m.Read()).Returns(new List<Recipe>());

            var query = new GetAllRecipesQuery();

            // act 
            var actual = this.RunQuery(query);

            // assert
            actual.Should().BeEmpty();
        }
    }
}
