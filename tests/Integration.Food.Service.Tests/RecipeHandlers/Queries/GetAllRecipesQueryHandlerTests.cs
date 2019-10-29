using FluentAssertions;
using Food.IService.RecipeHandlers.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Integration.Food.Service.Tests.RecipeHandlers.Queries
{
    public class GetAllRecipesQueryHandlerTests : RecipeTestBase
    {
        public GetAllRecipesQueryHandlerTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void HappyPath()
        {
            // arrange
            var command1 = this.RecipeDataProvider.CreateCommand();
            var command2 = this.RecipeDataProvider.CreateCommand();

            this.RunCommand(command1);
            this.RunCommand(command2);

            var query = new GetAllRecipesQuery();

            // act
            var actual = this.RunQuery(query);

            // assert
            actual.Should().NotBeEmpty();
            actual.Should().HaveCount(2);

            actual.Should().SatisfyRespectively(
                first => first.Should().BeEquivalentTo(command1),
                second => second.Should().BeEquivalentTo(command2));
        }
    }
}
