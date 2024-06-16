using LazardFreres.CoffeeMachine.Application.Common.Interfaces;
using LazardFreres.CoffeeMachine.Application.Products;
using Microsoft.Extensions.DependencyInjection;

namespace LazardFreres.CoffeeMachine.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IProductService, ProductService>();
    }
}
