using Microsoft.Extensions.DependencyInjection;
using Restaurante.Application.Services;
using Restaurante.Infrastructure.Repositories;

namespace Restaurante.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IFoodApplicationService, FoodApplicationService>();
            return services;
        }

        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IFoodRepository, FoodRepository>();
            return services;
        }
    }
}