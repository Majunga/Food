using System;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using Food.IService.IngredientHandlers.Commands;
using Food.IService.IngredientHandlers.Queries;
using Xunit;
using Xunit.Abstractions;

namespace Integration.Food.Service.Tests.IngredientHandlers.Commands
{
    public class CreateIngredientCommandHandlerTests : IngredientTestBase
    {
        public CreateIngredientCommandHandlerTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        public void InvalidModel_ShouldThrow()
        {
            // arrange
            var command = new CreateIngredientCommand();
            
            // act
            Action act = () => this.RunCommand(command);

            // assert
            act.Should().Throw<ValidationException>();
        }

        [Fact]
        public void HappyPath()
        {
            // arrange
            var command = this.IngredientDataProvider.CreateCommand();
            
            // act
            this.RunCommand(command);

            // assert
            command.Id.Should().HaveValue();
            command.Id.Should().BeGreaterThan(0);

            var actual = this.RunQuery(new GetIngredientByIdQuery(command.Id.Value));
            actual.Should().BeEquivalentTo(command);
        }
    }
}
