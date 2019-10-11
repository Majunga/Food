using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;
using Common.EnumDataTypes;
using FluentAssertions;
using Xunit;

namespace Common.Tests.DataTypeTests
{
    public class IngredientQuantityTests
    {
        [Fact]
        public void Mls_ShouldBeSetCorrectly()
        {
            // arrange
            var expectedQuantityType = QuantityType.Millilitres;
            var expectedQuantity = 120m;

            // act
            var actual = new IngredientQuantity(expectedQuantityType, expectedQuantity);

            // assert
            actual.QuantityType.Should().Be(expectedQuantityType);
            actual.Quantity.Should().Be(expectedQuantity);
        }

        [Fact]
        public void Grams_ShouldBeSetCorrectly()
        {
            // arrange
            var expectedQuantityType = QuantityType.Gram;
            var expectedQuantity = 30m;

            // act
            var actual = new IngredientQuantity(expectedQuantityType, expectedQuantity);

            // assert
            actual.QuantityType.Should().Be(expectedQuantityType);
            actual.Quantity.Should().Be(expectedQuantity);
        }
    }
}
