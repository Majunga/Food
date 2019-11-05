using FluentAssertions;
using Food.IService.RecipeHandlers.Models;
using Food.IService.RecipeHandlers.Queries;
using Food.Models.Recipes;
using Food.ViewModels.Recipes;
using Moq;
using System;
using System.Collections.Generic;
using Unit.Food.Tests.Pages;
using Xunit;

namespace Unit.Food.Tests.ViewModels.Recipes
{
    public class GridViewModelTests : PageTestBase
    {
        private IGridViewModel _target;

        public GridViewModelTests()
        {
            _target = new GridViewModel(MockNavigationManager.Object, MockDomainServices.Object);
        }

        [Fact]
        public void LoadGrid_NoRecipes_ShouldReturnEmpty()
        {
            // arrange
            var expected = new List<RecipeDto>();
            MockOnInitialized(expected);

            // act
            _target.LoadGrid();

            // assert
            _target.Model.Should().BeEmpty();
        }

        [Fact]
        public void LoadGrid_HappyPath()
        {
            // arrange
            var expected = CreateList();
            MockOnInitialized(expected);

            // act
            _target.LoadGrid();

            // assert
            _target.Model.Should().NotBeEmpty();
            _target.Model.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("Description")]
        [InlineData("Name")]
        public void Reorder_Aesc_ShouldOrderCorrecly(string column)
        {
                        // arrange
            var expected = CreateList();
            MockOnInitialized(expected);
            _target.LoadGrid();

            // act
            _target.Reorder(column);

            if(column == "Name") _target.Reorder(column);

            // assert
            if(column == "Name") _target.Model.Should().BeInAscendingOrder(m => m.Name);
            else  _target.Model.Should().BeInAscendingOrder(m => m.Description);
        }

        [Theory]
        [InlineData("Name")]
        [InlineData("Description")]
        public void Reorder_Desc_ShouldOrderCorrecly(string column)
        {
                        // arrange
            var expected = CreateList();
            MockOnInitialized(expected);
            _target.LoadGrid();

            // act
            _target.Reorder(column);

            // assert
            if(column == "Name") _target.Model.Should().BeInDescendingOrder(m => m.Name);
            else  _target.Model.Should().BeInDescendingOrder(m => m.Description);
        }

        private void MockOnInitialized(IReadOnlyCollection<RecipeDto> expected)
        {
            MockDomainServices.Setup(m => m.RunQuery(It.IsAny<GetAllRecipesQuery>())).Returns(expected);
            MockDomainServices
                .Setup(m => m.Convert<List<RecipeViewModel>>(It.IsAny<IReadOnlyCollection<RecipeDto>>()))
                .Returns((IReadOnlyCollection<RecipeDto> dto) => Convert<List<RecipeViewModel>>(dto));
        }

        private IReadOnlyCollection<RecipeDto> CreateList()
        {
            return new List<RecipeDto>
            {
                new RecipeDto
                {
                    Id = 1,
                    Name = Guid.NewGuid().ToString()
                },
                new RecipeDto
                {
                    Id = 2,
                    Name = Guid.NewGuid().ToString()
                }
            };
        }
    }
}
