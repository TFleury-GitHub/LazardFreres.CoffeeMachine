namespace LazardFreres.CoffeeMachine.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<RecipeElement> RecipeElements { get; set; }

    public Product(string name, ICollection<RecipeElement> recipeElements)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(recipeElements);

        Name = name;
        RecipeElements = recipeElements;
    }

    public decimal GetProductPrice(int marginPercentage)
    {
        var productPrice = RecipeElements.Sum(element => 
            element.Ingredient.Price * element.Quantity);

        var margin = productPrice * (marginPercentage / 100m);

        var finalPrice = Math.Round(productPrice + margin, 2);

        return finalPrice;
    }
}
