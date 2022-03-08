using Restaurante.Core.Models;
using Restaurante.Infrastructure.EntityFramework;
using System;
using System.Linq;

namespace Restaurante.Infrastructure.Repositories
{
    public interface IFoodRepository
    {
        void Add(Food food);

        void Delete(Food food);

        Food GetById(int id);

        void Update(Food food);
    }

    public class FoodRepository : IFoodRepository
    {
        private readonly RestauranteContext _context;

        public FoodRepository(RestauranteContext context) => _context = context;

        public void Add(Food food)
        {
            _context.Foods.Add(food);
            _context.SaveChanges();
        }

        public void Delete(Food food)
        {
            _context.Foods.Remove(food);
            _context.SaveChanges();
        }

        public Food GetById(int id)
        {
            return GetBy(food => food.Id == id);
        }

        public void Update(Food food)
        {
            _context.Foods.Update(food);
            _context.SaveChanges();
        }

        private Food GetBy(Func<Food, bool> predicate)
        {
            return _context.Foods.Where(predicate).FirstOrDefault();
        }
    }
}