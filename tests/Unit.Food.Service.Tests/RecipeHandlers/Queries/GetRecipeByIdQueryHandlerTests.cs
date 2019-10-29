using Common.Exceptions.NotFound;
using FluentAssertions;
using Food.IService.RecipeHandlers.Queries;
using Moq;
using System;
using Xunit;

namespace Unit.Food.Service.Tests.RecipeHandlers.Queries
{
    public class GetRecipeByIdQueryHandlerTests : ServiceTestBase
    {
        [Fact]
        public void RecipeDoesntExist_ShouldThrow()
        {
            // arrange
            var query = new GetRecipeByIdQuery(int.MaxValue);
            this.MockRecipeRepository.Setup(m => m.Read(It.IsAny<int>())).Returns(()=> null);

            // act
            Action act = () => this.RunQuery(query);
            
            // assert
            act.Should().Throw<RecipeNotFoundException>();
        }
    }
}
