using FluentAssertions;
using Food.IService.RecipeHandlers.Commands;
using Moq;
using System;
using Xunit;

namespace Unit.Food.Service.Tests.RecipeHandlers.Commands
{
    public class DeleteRecipeCommandHandlerTests : ServiceTestBase
    {
        [Fact]
        public void RecipeNotFound_ShouldNotThrow()
        {
            // arrange
            this.MockRecipeRepository.Setup(m => m.Read(It.IsAny<int>())).Returns(() => null);

            var command = new DeleteRecipeCommand(int.MaxValue);

            // act
            Action act = () => this.RunCommand(command);

            // assert
            act.Should().NotThrow();
        }
    }
}
