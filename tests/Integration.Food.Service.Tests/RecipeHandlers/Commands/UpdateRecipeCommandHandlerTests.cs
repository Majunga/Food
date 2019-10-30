using FluentAssertions;
using Food.IService.RecipeHandlers.Commands;
using Food.IService.RecipeHandlers.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Integration.Food.Service.Tests.RecipeHandlers.Commands
{
    public class UpdateRecipeCommandHandlerTests : RecipeTestBase
    {
        public UpdateRecipeCommandHandlerTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void InvalidModel_ShouldThrow()
        {
            // arrange
            var createCommand = this.RecipeDataProvider.CreateCommand();
            this.RunCommand(createCommand);

            var updateCommand = new UpdateRecipeCommand
            {
                Id = createCommand.Id.Value
            };

            // act 
            Action act = () => this.RunCommand(updateCommand);

            // assert
            act.Should().Throw<ValidationException>();
        }

        [Fact]
        public void HappyPath()
        {
            // arrange
            var createCommand = this.RecipeDataProvider.CreateCommand();
            this.RunCommand(createCommand);

            var updateCommand = new UpdateRecipeCommand
            {
                Id = createCommand.Id.Value,
                Name = "Test",
                Description = "Description Test"
            };

            // act 
            this.RunCommand(updateCommand);

            // assert
            var actual = this.RunQuery(new GetRecipeByIdQuery(updateCommand.Id));
            actual.Should().BeEquivalentTo(updateCommand);
        }
    }
}
