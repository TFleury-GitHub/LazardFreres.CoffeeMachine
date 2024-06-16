using LazardFreres.CoffeeMachine.Application.Common.Interfaces;
using LazardFreres.CoffeeMachine.Application.Products.Models;
using Microsoft.AspNetCore.Mvc;

namespace LazardFreres.CoffeeMachine.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
    }

    [HttpGet]
    public async Task<ICollection<ProductDto>> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();

        return products;
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<ProductWithPriceDto>> GetProductById(int productId)
    {
        var product = await _productService.GetProductWithPriceAsync(productId);

        if (product is null)
        {
            return NotFound();
        }

        return product;
    }
}
