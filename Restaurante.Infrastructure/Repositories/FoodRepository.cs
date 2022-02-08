using Restaurante.Core.Models;
using Restaurante.Infrastructure.EntityFramework;

namespace Restaurante.Infrastructure.Repositories
{
    public interface IFoodRepository
    {
        void Add(Food food);
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
    }
}