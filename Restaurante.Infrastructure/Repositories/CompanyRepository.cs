using Microsoft.EntityFrameworkCore;
using Restaurante.Core.Models;
using Restaurante.Infrastructure.EntityFramework;
using Restaurante.Infrastructure.Repositories.Intefaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante.Infrastructure.Repositories
{
    public class CompanyRepository : IBaseRepository<Company>
    {
        private readonly RestauranteContext _context;

        public CompanyRepository(RestauranteContext context) => _context = context;

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Company>> GetAllAsync(PaginationFilter filter)
        {
            return await _context.Companies
               .Include(f => f.Address)
               .Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _context
                 .Companies.Where(f => f.Id == id)
                 .Include(f => f.Address)
                 .FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Company company)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }
    }
}