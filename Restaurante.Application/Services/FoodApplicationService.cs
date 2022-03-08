using Restaurante.Core.Models;
using Restaurante.Infrastructure.Repositories;

namespace Restaurante.Application.Services
{
    public interface IFoodApplicationService
    {
        public void Add(Food food);

        public void Update(Food food);
    }

    public class FoodApplicationService : IFoodApplicationService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodApplicationService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public void Add(Food food) => _foodRepository.Add(food);

        public void Update(Food food) => _foodRepository.Update(food);
    }
}