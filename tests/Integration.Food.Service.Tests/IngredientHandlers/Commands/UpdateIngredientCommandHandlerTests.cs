using FluentAssertions;
using Food.IService.IngredientHandlers.Commands;
using Food.IService.IngredientHandlers.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Integration.Food.Service.Tests.IngredientHandlers.Commands
{
    public class UpdateIngredientCommandHandlerTests : IngredientTestBase
    {
        public UpdateIngredientCommandHandlerTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void InvalidModel_ShouldThrow()
        {
            // arrange
            var createCommand = this.IngredientDataProvider.CreateCommand();
            this.RunCommand(createCommand);

            var updateCommand = new UpdateIngredientCommand
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
            var createCommand = this.IngredientDataProvider.CreateCommand();
            this.RunCommand(createCommand);

            var updateCommand = new UpdateIngredientCommand
            {
                Id = createCommand.Id.Value,
                Name = "Test"
            };

            // act 
            this.RunCommand(updateCommand);

            // assert
            var actual = this.RunQuery(new GetIngredientByIdQuery(updateCommand.Id));
            actual.Should().BeEquivalentTo(updateCommand);
        }
    }
}
