namespace LazardFreres.CoffeeMachine.Application.Products.Models;

public class ProductWithPriceDto : ProductDto
{
    public decimal Price { get; set; }

    public ProductWithPriceDto(int id, string name, decimal price) : base(id, name)
    {
        Price = price;
    }
}
