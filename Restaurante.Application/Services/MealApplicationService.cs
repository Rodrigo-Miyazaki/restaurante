using Restaurante.Application.Services.Interfaces;
using Restaurante.Core.Models;
using Restaurante.Infrastructure.Repositories.Intefaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurante.Application.Services
{
    public class MealApplicationService : IBaseApplicationService<Meal>
    {
        private readonly IBaseRepository<Meal> _mealRepository;

        public MealApplicationService(IBaseRepository<Meal> mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task AddAsync(Meal meal) => await _mealRepository.AddAsync(meal);

        public async Task<List<Meal>> GetAllAsync(PaginationFilter filter) => await _mealRepository.GetAllAsync(filter);

        public async Task<Meal> GetByIdAsync(int id) => await _mealRepository.GetByIdAsync(id);

        public async Task RemoveAsync(int id)
        {
            var meal = new Meal { Id = id };
            await _mealRepository.RemoveAsync(meal);
        }

        public async Task UpdateAsync(Meal meal) => await _mealRepository.UpdateAsync(meal);
    }
}