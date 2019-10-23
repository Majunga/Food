using Common.Exceptions.NotFound;
using FluentAssertions;
using Food.Dal.Models;
using Food.IService.IngredientHandlers.Commands;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Unit.Food.Service.Tests.IngredientHandlers.Commands
{
    public class UpdateIngredientCommandHandlerTests : ServiceTestBase
    {
        [Fact]
        public void IngredientDoesntExist_ShouldThrow()
        {
            // arrange
            this.MockUnitOfWork.Setup(m => m.IngredientRepository.Read(It.IsAny<int>())).Returns(() => null);
            var command = new UpdateIngredientCommand();

            // act 
            Action act = () => this.DomainServices.RunCommand(command);

            // assert
            act.Should().Throw<IngredientNotFoundException>();
        }
    }
}
