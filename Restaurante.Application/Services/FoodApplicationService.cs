using Restaurante.Application.Services.Interfaces;
using Restaurante.Core.Models;
using Restaurante.Infrastructure.Repositories.Intefaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurante.Application.Services
{
    public class FoodApplicationService : IBaseApplicationService<Food>
    {
        private readonly IBaseRepository<Food> _foodRepository;

        public FoodApplicationService(IBaseRepository<Food> foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task AddAsync(Food food) => await _foodRepository.AddAsync(food);

        public async Task RemoveAsync(int id)
        {
            var food = new Food { Id = id };
            await _foodRepository.RemoveAsync(food);
        }

        public async Task<Food> GetByIdAsync(int id) => await _foodRepository.GetByIdAsync(id);

        public async Task UpdateAsync(Food food) => await _foodRepository.UpdateAsync(food);

        public async Task<List<Food>> GetAllAsync(PaginationFilter filter) => await _foodRepository.GetAllAsync(filter);
    }
}