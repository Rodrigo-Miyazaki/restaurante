using Restaurante.Application.Interfaces.Services;
using Restaurante.Core.Models;
using Restaurante.Infrastructure.Repositories.Intefaces;
using System;
using System.Threading.Tasks;

namespace Restaurante.Application.Services
{
    public class MealFoodApplicationService : IMealFoodApplicationService
    {
        private readonly IMealFoodRepository _mealFoodRepository;

        public MealFoodApplicationService(IMealFoodRepository mealFoodRepository)
        {
            _mealFoodRepository = mealFoodRepository;
        }

        public Task AddAsync(MealFood mealFood) => _mealFoodRepository.AddAsync(mealFood);
    }
}