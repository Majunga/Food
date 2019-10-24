using Common.Exceptions.NotFound;
using FluentAssertions;
using Food.IService.IngredientHandlers.Commands;
using System;
using Xunit;

namespace Unit.Food.Service.Tests.IngredientHandlers.Commands
{
    public class DeleteIngredientCommandHandlerTests : ServiceTestBase
    {
        [Fact]
        public void IngredientDoesntExist_ShouldNotThrow()
        {
            // arrange
            var command = new DeleteIngredientCommand(int.MaxValue);

            // act 
            Action act = () => this.DomainServices.RunCommand(command);

            // assert
            act.Should().NotThrow<IngredientNotFoundException>();
        }
    }
}
