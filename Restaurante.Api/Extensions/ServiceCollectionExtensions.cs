using Microsoft.Extensions.DependencyInjection;
using Restaurante.Application.Interfaces.Services;
using Restaurante.Application.Services;
using Restaurante.Application.Services.Interfaces;
using Restaurante.Core.Models;
using Restaurante.Infrastructure.Repositories;
using Restaurante.Infrastructure.Repositories.Intefaces;

namespace Restaurante.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseApplicationService<Food>, FoodApplicationService>();
            services.AddScoped<IBaseApplicationService<Company>, CompanyApplicationService>();
            services.AddScoped<IBaseApplicationService<Meal>, MealApplicationService>();

            services.AddScoped<IMealCompanyApplicationService, MealCompanyApplicationService>();
            return services;
        }

        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Food>, FoodRepository>();
            services.AddScoped<IBaseRepository<Company>, CompanyRepository>();
            services.AddScoped<IBaseRepository<Meal>, MealRepository>();

            services.AddScoped<IMealCompanyRepository, MealCompanyRepository>();
            return services;
        }
    }
}