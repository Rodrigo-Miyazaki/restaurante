using Restaurante.Core.Models;
using Restaurante.Infrastructure.EntityFramework;
using Restaurante.Infrastructure.Repositories.Intefaces;
using System.Threading.Tasks;

namespace Restaurante.Infrastructure.Repositories
{
    public class MealCompanyRepository : IMealCompanyRepository
    {
        private readonly RestauranteContext _context;

        public MealCompanyRepository(RestauranteContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MealCompany mealCompany)
        {
            await _context.MealCompany.AddAsync(mealCompany);
            await _context.SaveChangesAsync();
        }
    }
}