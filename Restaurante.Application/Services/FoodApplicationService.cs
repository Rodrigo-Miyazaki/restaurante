using Restaurante.Application.Interfaces;
using Restaurante.Core.Models;
using Restaurante.Infrastructure.Repositories.Intefaces;

namespace Restaurante.Application.Services
{
    public class FoodApplicationService : IBaseApplicationService<Food>
    {
        private readonly IBaseRepository<Food> _foodRepository;

        public FoodApplicationService(IBaseRepository<Food> foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public void Add(Food food) => _foodRepository.Add(food);

        public void Remove(int id)
        {
            var food = new Food { Id = id };
            _foodRepository.Remove(food);
        }

        public Food GetById(int id) => _foodRepository.GetById(id);

        public void Update(Food food) => _foodRepository.Update(food);
    }
}