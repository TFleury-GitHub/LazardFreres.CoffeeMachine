using FluentAssertions;
using LazardFreres.CoffeeMachine.Domain.Entities;

namespace LazardFreres.CoffeeMachine.Domain.UnitTests;

public class RecipeElementTests
{
    [Fact]
    public void Should_Throw_Exception_When_Ingredient_Is_Null()
    {
        // Arrange
        Ingredient ingredient = null;
        var quantity = 1;

        // Act
        var act = () => { var recipeElement = new RecipeElement(ingredient, quantity); };

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Should_Throw_Exception_When_Quantity_Is_Not_Positive(int quantity)
    {
        // Arrange
        var ingredient = new Ingredient("name", 1);

        // Act
        var act = () => { var recipeElement = new RecipeElement(ingredient, quantity); };

        // Assert
        act.Should().Throw<Exception>();
    }

    [Fact]
    public void Should_Create_RecipeElement_When_Quantity_Is_Positive()
    {
        // Arrange
        var ingredient = new Ingredient("name", 1);
        var quantity = 1;

        // Act
        var recipeElement = new RecipeElement(ingredient, quantity);

        // Assert
        recipeElement.Ingredient.Should().Be(ingredient);
        recipeElement.Quantity.Should().Be(quantity);
    }
}