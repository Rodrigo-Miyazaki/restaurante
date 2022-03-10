using Microsoft.EntityFrameworkCore;
using Restaurante.Core.Models;
using Restaurante.Infrastructure.EntityFramework;
using Restaurante.Infrastructure.Repositories.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Restaurante.Infrastructure.Repositories
{
    public class FoodRepository : IBaseRepository<Food>
    {
        private readonly RestauranteContext _context;

        public FoodRepository(RestauranteContext context) => _context = context;

        public async Task AddAsync(Food food)
        {
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Food food)
        {
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
        }

        public async Task<Food> GetByIdAsync(int id)
        {
            return await GetByAsync(food => food.Id == id);
        }

        public async Task UpdateAsync(Food food)
        {
            _context.Foods.Update(food);
            await _context.SaveChangesAsync();
        }

        private async Task<Food> GetByAsync(Expression<Func<Food, bool>> predicate)
        {
            return await _context.Foods.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<Food>> GetAllAsync(PaginationFilter filter)
        {
            return await _context.Foods
               .Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .ToListAsync();
        }
    }
}