using FluentAssertions;
using Food.IService.RecipeHandlers.Queries;
using Xunit;
using Xunit.Abstractions;

namespace Integration.Food.Service.Tests.RecipeHandlers.Queries
{
    public class GetRecipeByIdQueryHandlerTests : RecipeTestBase
    {
        public GetRecipeByIdQueryHandlerTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void HappyPath()
        {
            // arrange
            var command = this.RecipeDataProvider.CreateCommand();
            this.RunCommand(command);

            var query = new GetRecipeByIdQuery(command.Id.Value);

            // act
            var actual = this.RunQuery(query);

            // assert
            actual.Should().BeEquivalentTo(command);
        }
    }
}
