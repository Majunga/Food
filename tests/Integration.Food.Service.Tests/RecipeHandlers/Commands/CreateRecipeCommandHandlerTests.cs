using FluentAssertions;
using Food.IService.RecipeHandlers.Commands;
using Food.IService.RecipeHandlers.Queries;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Abstractions;

namespace Integration.Food.Service.Tests.RecipeHandlers.Commands
{
    public class CreateRecipeCommandHandlerTests : RecipeTestBase
    {
        public CreateRecipeCommandHandlerTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void InvalidModel_ShouldThrow()
        {
            // arrange
            var command = new CreateRecipeCommand();

            // act
            Action act = () => this.RunCommand(command);

            // assert
            act.Should().Throw<ValidationException>();
        }
        
        [Fact]
        public void HappyPath()
        {
            // arrange
            var command = this.RecipeDataProvider.CreateCommand();

            // act
            this.RunCommand(command);

            // assert
            command.Id.Should().HaveValue();
            command.Id.Should().BeGreaterThan(0);

            var actual = this.RunQuery(new GetRecipeByIdQuery(command.Id.Value));

            actual.Should().BeEquivalentTo(command);
        }
    }
}
