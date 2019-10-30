using Common.Exceptions.NotFound;
using FluentAssertions;
using Food.IService.RecipeHandlers.Commands;
using Moq;
using System;
using Xunit;

namespace Unit.Food.Service.Tests.RecipeHandlers.Commands
{
    public class UpdateRecipeCommandHandlerTests : ServiceTestBase
    {
        [Fact]
        public void RecipeDoesntExist_ShouldThrow()
        {
            // arrange 
            this.MockRecipeRepository.Setup(m => m.Read(It.IsAny<int>())).Returns(() => null);
            
            var command = new UpdateRecipeCommand();

            // act
            Action act = () => this.RunCommand(command);

            // assert
            act.Should().Throw<RecipeNotFoundException>();
        }
    }
}
