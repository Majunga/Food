using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Food.IService.IngredientHandlers.Queries;
using Xunit;
using Xunit.Abstractions;

namespace Integration.Food.Service.Tests.IngredientHandlers.Queries
{
    public class GetAllIngredientsQueryHandlerTests : IngredientTestBase
    {
        public GetAllIngredientsQueryHandlerTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void NoIngredients_ShouldBeEmpty()
        {
            // arrange
            var query = new GetAllIngredientsQuery();

            // act
            var actual = this.RunQuery(query);

            // assert
            actual.Should().BeEmpty();
        }

        [Fact]
        public void SingleIngredient_ShouldReturnOne()
        {
            // arrange
            var expected = this.IngredientDataProvider.CreateCommand();
            this.RunCommand(expected);
            
            var query = new GetAllIngredientsQuery();

            // act
            var actual = this.RunQuery(query);

            // assert
            actual.Should().NotBeEmpty();
            actual.Should().HaveCount(1);
            actual.First().Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SeveralIngredients_ShouldReturnAll()
        {
            // arrange
            var expected1 = this.IngredientDataProvider.CreateCommand();
            var expected2 = this.IngredientDataProvider.CreateCommand();
            var expected3 = this.IngredientDataProvider.CreateCommand();

            this.RunCommand(expected1);
            this.RunCommand(expected2);
            this.RunCommand(expected3);
            
            var query = new GetAllIngredientsQuery();

            // act
            var actual = this.RunQuery(query).ToArray();

            // assert
            actual.Should().NotBeEmpty();
            actual.Should().HaveCount(3);

            actual[0].Should().BeEquivalentTo(expected1);
            actual[1].Should().BeEquivalentTo(expected2);
            actual[2].Should().BeEquivalentTo(expected3);
        }
    }
}
