using LazardFreres.CoffeeMachine.Application.Common.Interfaces.Repositories;
using LazardFreres.CoffeeMachine.Domain.Entities;
using System.Linq;

namespace LazardFreres.CoffeeMachine.Infrastructure.Persistence;

public class ProductRepository : IProductRepository
{
    private record IngredientItem(string Code, string Name, decimal Price);
    private record IngredientItemQuantity(string IngredientCode, int Quantity);
    private record ProductItem(string Name, ICollection<IngredientItemQuantity> Recipe);

    private readonly ICollection<IngredientItem> _ingredientItems = new List<IngredientItem>()
    {
        new IngredientItem("lait", "Lait en poudre", 0.10m), 
        new IngredientItem("cafe", "Café", 0.30m),
        new IngredientItem("chocolat", "Chocolat", 0.40m),
        new IngredientItem("the", "Thé", 0.30m),
        new IngredientItem("eau", "Eau", 0.05m),
    };

    private readonly ICollection<ProductItem> _productItems = new List<ProductItem>()
    {
        new ProductItem("Espresso", new List<IngredientItemQuantity>() { new("eau", 2), new("cafe", 1) }),
        new ProductItem("Lait", new List<IngredientItemQuantity>() { new("lait", 2), new("eau", 1) }),
        new ProductItem("Capuccino", new List<IngredientItemQuantity>() { new("lait", 2), new("eau", 1), new("cafe", 1), new("chocolat", 1) }),
        new ProductItem("Chocolat chaud", new List<IngredientItemQuantity>() { new("eau", 3), new("chocolat", 2) }),
        new ProductItem("Café au lait", new List<IngredientItemQuantity>() { new("lait", 1), new("eau", 2), new("cafe", 1) }),
        new ProductItem("Mokaccino", new List<IngredientItemQuantity>() { new("lait", 1), new("eau", 2), new("cafe", 1), new("chocolat", 2) }),
        new ProductItem("Thé", new List<IngredientItemQuantity>() { new("eau", 2), new("the", 1) }),
    };

    private readonly ICollection<Product> _allProducts;

    public ProductRepository()
    {
        _allProducts = CreateProductDataSet();
    }

    private ICollection<Product> CreateProductDataSet()
    {
        var indredients = _ingredientItems.ToDictionary(
            item => item.Code,
            item => new Ingredient(item.Name, item.Price));

        var productId = 1;

        return _productItems.Select(productItem =>
        {
            var recipeElements = productItem.Recipe
                .Select(ingredientItem =>
                    new RecipeElement(
                        indredients[ingredientItem.IngredientCode],
                        ingredientItem.Quantity))
                .ToList();

            return new Product(productItem.Name, recipeElements) { Id = productId++ };
        }).ToList();
    }

    public async Task<ICollection<Product>> GetAllProductsAsync()
    {
        return await Task.FromResult(_allProducts);
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        return await Task.FromResult(_allProducts.FirstOrDefault(product => product.Id == productId));
    }
}
