using Common.Conversion;
using FluentAssertions;
using Food.IService;
using Food.IService.IngredientHandlers.Commands;
using Food.IService.IngredientHandlers.Models;
using Food.IService.IngredientHandlers.Queries;
using Food.Models.Ingredients;
using Majunga.RazorModal;
using Moq;
using Service.Conversion;
using System;
using System.Collections.Generic;
using Unit.Food.Tests.ExposedPageModels.Ingredients;
using Xunit;

namespace Unit.Food.Tests.Pages.Ingredients
{
    public class IndexTests : PageTestBase
    {
        [Fact]
        public void LoadIngredients_OnInitialized()
        {
            // arrange
            var expected = CreateList();
            MockOnInitialized(expected);

            var sut = CreateSut();

            // act
            sut.xOnInitialized();

            // assert
            sut.Ingredients.Should().NotBeEmpty();
            sut.Ingredients.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ShowModal_ShouldSetModalTitleCorrectly()
        {
            // arrange
            var expected = $"{Guid.NewGuid()}";
            var sut = CreateSut();

            // act
            sut.ShowModal(expected);

            // assert
            sut.xModalTitle.Should().Be($"{expected} ingredient");
        }

        //[Fact]
        //public void ShowModal_ShouldShowModal()
        //{
        //    // arrange
        //    var sut = CreateSut();
        //    this.MockModalService.Setup(m => m.Show()).Verifiable();

        //    // act
        //    sut.ShowModal(string.Empty);

        //    // assert
        //    this.MockModalService.Verify();
        //}

        [Fact]
        public void CreateIngredient_ShouldSave()
        {
            // arrange
            var sut = CreateSut();
            this.MockDomainServices.Setup(m => m.Convert<CreateIngredientCommand>(It.IsAny<IngredientViewModel>())).Verifiable();
            this.MockDomainServices.Setup(m => m.RunCommand(It.IsAny<CreateIngredientCommand>())).Verifiable();

            // act
            sut.SaveModal();

            // assert
            this.MockDomainServices.Verify();
        }

        [Fact]
        public void UpdateIngredient_ShouldSave()
        {
            // arrange
            var sut = CreateSut();
            this.MockDomainServices.Setup(m => m.Convert<UpdateIngredientCommand>(It.IsAny<IngredientViewModel>())).Verifiable();
            this.MockDomainServices.Setup(m => m.RunCommand(It.IsAny<UpdateIngredientCommand>())).Verifiable();

            sut.xModel = new IngredientViewModel{Id = 1};

            // act
            sut.SaveModal();

            // assert
            this.MockDomainServices.Verify();
        }

        [Fact]
        public void DeleteIngredient_ShouldSave()
        {
            // arrange
            var sut = CreateSut();
            this.MockDomainServices.Setup(m => m.RunCommand(It.IsAny<DeleteIngredientCommand>())).Verifiable();

            // act
            sut.DeleteIngredient(int.MaxValue);

            // assert
            this.MockDomainServices.Verify();
        }

        [Fact]
        public void Reorder_ShouldOrderIngredientsCorrectly()
        {
            // arrange
            var expected = new List<IngredientDto>
            {
                new IngredientDto
                {
                    Id = 1,
                    Name = "b"
                },
                new IngredientDto
                {
                    Id = 2,
                    Name = "c"
                },
                new IngredientDto
                {
                    Id = 3,
                    Name = "a"
                }
            };

            MockOnInitialized(expected);

            var sut = CreateSut();
            sut.xOnInitialized();
            sut.Ingredients.Should().BeInAscendingOrder(i => i.Name);

            // act & assert
            sut.Reorder();
            sut.Ingredients.Should().BeInDescendingOrder(i => i.Name);

            sut.Reorder();
            sut.Ingredients.Should().BeInAscendingOrder(i => i.Name);
        }
        
        private void MockOnInitialized(IReadOnlyCollection<IngredientDto> expected)
        {
            this.MockDomainServices.Setup(m => m.RunQuery(It.IsAny<GetAllIngredientsQuery>())).Returns(expected);
            this.MockDomainServices
                .Setup(m => m.Convert<List<IngredientViewModel>>(It.IsAny<IReadOnlyCollection<IngredientDto>>()))
                .Returns((IReadOnlyCollection<IngredientDto> dto) => this.Convert<List<IngredientViewModel>>(dto));
        }

        private IReadOnlyCollection<IngredientDto> CreateList()
        {
            return new List<IngredientDto>
            {
                new IngredientDto
                {
                    Id = 1,
                    Name = Guid.NewGuid().ToString()
                },
                new IngredientDto
                {
                    Id = 2,
                    Name = Guid.NewGuid().ToString()
                }
            };
        }

        private IndexWrapper CreateSut()
        {
            var sut = new IndexWrapper();

            sut.xModalService = this.MockModalService.Object;
            sut.xDomainServices = this.MockDomainServices.Object;

            return sut;
        }
    }
}
