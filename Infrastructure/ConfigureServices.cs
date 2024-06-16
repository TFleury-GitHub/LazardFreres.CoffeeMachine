using LazardFreres.CoffeeMachine.Application.Common.Interfaces.Repositories;
using LazardFreres.CoffeeMachine.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace LazardFreres.CoffeeMachine.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IProductRepository, ProductRepository>();
    }
}
