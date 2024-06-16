using LazardFreres.CoffeeMachine.Application.Products.Models;

namespace LazardFreres.CoffeeMachine.Application.Common.Interfaces;

public interface IProductService
{
    Task<ICollection<ProductDto>> GetAllProductsAsync();
    Task<ProductWithPriceDto> GetProductWithPriceAsync(int productId);
}
