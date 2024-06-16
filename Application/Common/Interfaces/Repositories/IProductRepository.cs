using LazardFreres.CoffeeMachine.Domain.Entities;

namespace LazardFreres.CoffeeMachine.Application.Common.Interfaces.Repositories;

public interface IProductRepository
{
    Task<ICollection<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int productId);
}
