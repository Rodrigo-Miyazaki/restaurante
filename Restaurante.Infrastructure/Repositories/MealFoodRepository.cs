using Restaurante.Core.Models;
using Restaurante.Infrastructure.EntityFramework;
using Restaurante.Infrastructure.Repositories.Intefaces;
using System.Threading.Tasks;

namespace Restaurante.Infrastructure.Repositories
{
    public class MealFoodRepository : IMealFoodRepository
    {
        private readonly RestauranteContext _context;

        public MealFoodRepository(RestauranteContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MealFood mealFood)
        {
            await _context.MealFood.AddAsync(mealFood);
            await _context.SaveChangesAsync();
        }
    }
}