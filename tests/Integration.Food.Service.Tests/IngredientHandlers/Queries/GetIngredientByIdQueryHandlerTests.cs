using System;
using Common.Exceptions.NotFound;
using FluentAssertions;
using Food.IService.IngredientHandlers.Queries;
using Xunit;
using Xunit.Abstractions;

namespace Integration.Food.Service.Tests.IngredientHandlers.Queries
{
    public class GetIngredientByIdQueryHandlerTests : IngredientTestBase
    {
        public GetIngredientByIdQueryHandlerTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void IngredientDoesntExist_ShouldThrow()
        {
            // arrange
            var query = new GetIngredientByIdQuery(int.MaxValue);

            // act
            Action act = () => this.RunQuery(query);

            // assert
            act.Should().Throw<IngredientNotFoundException>();
        }

        [Fact]
        public void HappyPath()
        {
            // arrange
            var command = this.IngredientDataProvider.CreateCommand();
            this.RunCommand(command);

            var query = new GetIngredientByIdQuery(command.Id.Value);

            // act
            var actual = this.RunQuery(query);

            // assert
            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(command);
        }
    }
}
