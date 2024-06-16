using LazardFreres.CoffeeMachine.Application.Common.Interfaces;
using LazardFreres.CoffeeMachine.Application.Common.Interfaces.Repositories;
using LazardFreres.CoffeeMachine.Application.Products.Models;

namespace LazardFreres.CoffeeMachine.Application.Products;

public class ProductService : IProductService
{
    private const int MarginPercentage = 30;

    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ICollection<ProductDto>> GetAllProductsAsync()
    {
        var allProducts = await _productRepository.GetAllProductsAsync();

        return allProducts.Select(product => new ProductDto(product.Id, product.Name)).ToList();
    }

    public async Task<ProductWithPriceDto> GetProductWithPriceAsync(int productId)
    {
        var productFound = await _productRepository.GetProductByIdAsync(productId);

        return productFound is null
            ? null
            : new ProductWithPriceDto(
                productFound.Id,
                productFound.Name,
                productFound.GetProductPrice(MarginPercentage));
    }
}
