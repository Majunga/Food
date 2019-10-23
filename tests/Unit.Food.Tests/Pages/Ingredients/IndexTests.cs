using Common.Conversion;
using FluentAssertions;
using Food.IService;
using Food.IService.IngredientHandlers.Commands;
using Food.IService.IngredientHandlers.Models;
using Food.IService.IngredientHandlers.Queries;
using Food.Models.Ingredients;
using Food.Pages.Ingredients;
using Majunga.RazorModal;
using Moq;
using Service.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Unit.Food.Tests.Pages.Ingredients
{
    public class IndexTests
    {
        public IndexTests()
        {
            this.MockModalService = new Mock<ModalService>();
            this.MockDomainServices = new Mock<IServices>();

            var mapper = new ConversionConfiguration().MapperConfig.CreateMapper();
            this.Converter = new AutoMapperConversionService(mapper);

        }

        public Mock<ModalService> MockModalService { get; private set; }
        public Mock<IServices> MockDomainServices { get; private set; }
        public AutoMapperConversionService Converter { get; }

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
        public void SaveModal_ShouldSave()
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

        protected T Convert<T>(object source)
        {
            return (T)this.Converter.Convert(source, typeof(T));
        }

        protected void Map(object source, object target)
        {
            this.Converter.Map(source, target);
        }
    }

    public class IndexWrapper : IndexBase
    {
        public ModalService xModalService { get => base.ModalService; set => base.ModalService = value; }
        public IServices xDomainServices { get => base.DomainServices; set => base.DomainServices = value; }

        public IEnumerable<IngredientViewModel> Ingredients => base.ingredients;
        public string xModalTitle => base.ModalTitle;

        public void xOnInitialized()
        {
            base.OnInitialized();
        }
    }
}
