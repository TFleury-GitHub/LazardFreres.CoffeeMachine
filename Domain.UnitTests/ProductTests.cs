using FluentAssertions;
using LazardFreres.CoffeeMachine.Domain.Entities;

namespace LazardFreres.CoffeeMachine.Domain.UnitTests;

public class ProductTests
{
    [Fact]
    public void Should_Return_Sum_Of_Ingredient_Prices_When_Margin_Is_Zero()
    {
        // Arrange
        var price1 = 0.50m;
        var quantity1 = 2;

        var price2 = 0.10m;
        var quantity2 = 3;

        var marginPercentage = 0;

        var expectedPrice = 1.30m;

        var recipeElements = new List<RecipeElement>()
        {
            new RecipeElement(new Ingredient("ingredient1", price1), quantity1),
            new RecipeElement(new Ingredient("ingredient2", price2), quantity2),
        };

        var product = new Product("product1", recipeElements);

        // Act
        var price = product.GetProductPrice(marginPercentage);

        // Assert
        price.Should().Be(expectedPrice);
    }

    [Fact]
    public void Should_Return_Sum_Of_Ingredient_Prices_Plus_Margin_When_Margin_Is_Positive()
    {
        // Arrange
        var price1 = 0.50m;
        var quantity1 = 2;

        var price2 = 0.10m;
        var quantity2 = 3;

        var marginPercentage = 50;

        var expectedPrice = 1.95m;

        var recipeElements = new List<RecipeElement>()
        {
            new RecipeElement(new Ingredient("ingredient1", price1), quantity1),
            new RecipeElement(new Ingredient("ingredient2", price2), quantity2),
        };

        var product = new Product("product1", recipeElements);

        // Act
        var price = product.GetProductPrice(marginPercentage);

        // Assert
        price.Should().Be(expectedPrice);
    }

    [Fact]
    public void Should_Return_Sum_Of_Ingredient_Prices_Plus_Margin_Rounded_When_Margin_Is_Positive()
    {
        // Arrange
        var price1 = 0.50m;
        var quantity1 = 2;

        var price2 = 0.10m;
        var quantity2 = 3;

        var marginPercentage = 19;

        var expectedPrice = 1.55m;

        var recipeElements = new List<RecipeElement>()
        {
            new RecipeElement(new Ingredient("ingredient1", price1), quantity1),
            new RecipeElement(new Ingredient("ingredient2", price2), quantity2),
        };

        var product = new Product("product1", recipeElements);

        // Act
        var price = product.GetProductPrice(marginPercentage);

        // Assert
        price.Should().Be(expectedPrice);
    }
}