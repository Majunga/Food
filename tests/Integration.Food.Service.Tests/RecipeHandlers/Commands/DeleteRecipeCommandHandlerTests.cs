using FluentAssertions;
using Food.IService.RecipeHandlers.Commands;
using Food.IService.RecipeHandlers.Queries;
using Xunit;
using Xunit.Abstractions;

namespace Integration.Food.Service.Tests.RecipeHandlers.Commands
{
    public class DeleteRecipeCommandHandlerTests : RecipeTestBase
    {
        public DeleteRecipeCommandHandlerTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void HappyPath()
        {
            // arrange
            var otherRecipe = this.RecipeDataProvider.CreateCommand();
            var recipeToDelete = this.RecipeDataProvider.CreateCommand();

            this.RunCommand(otherRecipe);
            this.RunCommand(recipeToDelete);

            var command = new DeleteRecipeCommand(recipeToDelete.Id.Value);

            // act
            this.RunCommand(command);

            // assert
            var actual = this.RunQuery(new GetAllRecipesQuery());

            actual.Should().NotBeEmpty();
            actual.Should().HaveCount(1);
            actual.Should().NotContain(r => r.Id == recipeToDelete.Id);
        }
    }
}
