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
    public class MealRepository : IBaseRepository<Meal>
    {
        private readonly RestauranteContext _context;

        public MealRepository(RestauranteContext context) => _context = context;

        public async Task AddAsync(Meal meal)
        {
            await _context.Meals.AddAsync(meal);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Meal meal)
        {
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
        }

        public async Task<Meal> GetByIdAsync(int id)
        {
            return await GetByAsync(meal => meal.Id == id);
        }

        public async Task UpdateAsync(Meal meal)
        {
            _context.Meals.Update(meal);
            await _context.SaveChangesAsync();
        }

        private async Task<Meal> GetByAsync(Expression<Func<Meal, bool>> predicate)
        {
            return await _context.Meals.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<Meal>> GetAllAsync(PaginationFilter filter)
        {
            return await _context.Meals
               .Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .ToListAsync();
        }
    }
}