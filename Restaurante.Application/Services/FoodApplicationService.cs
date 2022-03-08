﻿using Restaurante.Core.Models;
using Restaurante.Infrastructure.Repositories;

namespace Restaurante.Application.Services
{
    public interface IFoodApplicationService
    {
        public void Add(Food food);

        void Delete(int id);

        Food GetById(int id);

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

        public void Delete(int id)
        {
            var food = new Food { Id = id };
            _foodRepository.Delete(food);
        }

        public Food GetById(int id) => _foodRepository.GetById(id);

        public void Update(Food food) => _foodRepository.Update(food);
    }
}