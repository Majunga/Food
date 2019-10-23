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
    public class DeleteIngredientCommandHandlerTests : ServiceTestBase
    {
        [Fact]
        public void IngredientDoesntExist_ShouldNotThrow()
        {
            // arrange
            this.MockIngredientRepository.Setup(m => m.Read(It.IsAny<int>())).Returns(()=> throw new IngredientNotFoundException());
            var command = new DeleteIngredientCommand(int.MaxValue);

            // act 
            Action act = () => this.DomainServices.RunCommand(command);

            // assert
            act.Should().Throw<IngredientNotFoundException>();
        }
    }
}
