using Common.Conversion;
using FluentAssertions;
using Food.IService;
using Food.IService.RecipeHandlers.Commands;
using Food.IService.RecipeHandlers.Models;
using Food.IService.RecipeHandlers.Queries;
using Food.Models.Recipes;
using Food.Pages.Recipes;
using Majunga.RazorModal;
using Moq;
using Service.Conversion;
using System;
using System.Collections.Generic;
using Unit.Food.Tests.ExposedPageModels.Recipes;
using Xunit;

namespace Unit.Food.Tests.Pages.Recipes
{
    public class IndexTests : PageTestBase
    {
        [Fact]
        public void LoadRecipes_OnInitialized()
        {
            // arrange
            var expected = CreateList();
            MockOnInitialized(expected);

            var sut = CreateSut();

            // act
            sut.xOnInitialized();

            // assert
            sut.Recipes.Should().NotBeEmpty();
            sut.Recipes.Should().BeEquivalentTo(expected);
        }

        private void MockOnInitialized(IReadOnlyCollection<RecipeDto> expected)
        {
            this.MockDomainServices.Setup(m => m.RunQuery(It.IsAny<GetAllRecipesQuery>())).Returns(expected);
            this.MockDomainServices
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

        private IndexWrapper CreateSut()
        {
            var sut = new IndexWrapper(MockDomainServices.Object);
            return sut;
        }
    }
}
