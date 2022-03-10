using Microsoft.EntityFrameworkCore;
using Restaurante.Core.Models;
using Restaurante.Infrastructure.EntityFramework;
using Restaurante.Infrastructure.Repositories.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante.Infrastructure.Repositories
{
    public class FoodRepository : IBaseRepository<Food>
    {
        private readonly RestauranteContext _context;

        public FoodRepository(RestauranteContext context) => _context = context;

        public void Add(Food food)
        {
            _context.Foods.Add(food);
            _context.SaveChanges();
        }

        public void Remove(Food food)
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

        public async Task<List<Food>> GetAll(PaginationFilter filter)
        {
            return await _context.Foods
               .Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .ToListAsync();
        }
    }
}