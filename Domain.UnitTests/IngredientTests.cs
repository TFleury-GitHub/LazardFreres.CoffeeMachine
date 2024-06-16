using FluentAssertions;
using LazardFreres.CoffeeMachine.Domain.Entities;

namespace LazardFreres.CoffeeMachine.Domain.UnitTests;

public class IngredientTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Should_Throw_Exception_When_Ingredient_Price_Is_Not_Positive(int price)
    {
        // Arrange
        var name = "ingredientName";

        // Act
        var act = () => { var ingredient = new Ingredient(name, price); };

        // Assert
        act.Should().Throw<Exception>();
    }

    [Fact]
    public void Should_Create_Ingredient_When_Ingredient_Price_Is_Positive()
    {
        // Arrange
        var name = "ingredientName";
        var price = 1;

        // Act
        var ingredient = new Ingredient(name, price);

        // Assert
        ingredient.Name.Should().Be(name);
        ingredient.Price.Should().Be(price);
    }
}