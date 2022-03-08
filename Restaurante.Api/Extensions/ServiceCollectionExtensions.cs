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
            services.AddScoped<ICompanyApplicationService, CompanyApplicationService>();
            return services;
        }

        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            return services;
        }
    }
}