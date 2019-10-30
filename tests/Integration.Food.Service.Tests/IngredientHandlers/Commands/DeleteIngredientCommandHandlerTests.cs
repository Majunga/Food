using Common.Exceptions.NotFound;
using FluentAssertions;
using Food.IService.IngredientHandlers.Commands;
using Food.IService.IngredientHandlers.Queries;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Integration.Food.Service.Tests.IngredientHandlers.Commands
{
    public class DeleteIngredientCommandHandlerTests : IngredientTestBase
    {
        public DeleteIngredientCommandHandlerTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void HappyPath()
        {
            // arrange
            var createCommand = this.IngredientDataProvider.CreateCommand();
            this.RunCommand(createCommand);

            var deleteCommand = new DeleteIngredientCommand(createCommand.Id.Value);

            // act 
            this.RunCommand(deleteCommand);

            // assert
            Action actual = () => this.RunQuery(new GetIngredientByIdQuery(deleteCommand.IngredientId));
            actual.Should().Throw<IngredientNotFoundException>();
        }
    }
}
