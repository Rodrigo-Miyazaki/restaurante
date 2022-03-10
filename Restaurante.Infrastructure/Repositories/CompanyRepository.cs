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

        public void Add(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public async Task<List<Company>> GetAll(PaginationFilter filter)
        {
            return await _context.Companies
               .Include(f => f.Address)
               .Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .ToListAsync();
        }

        public Company GetById(int id)
        {
            return _context
                 .Companies.Where(f => f.Id == id)
                 .Include(f => f.Address)
                 .FirstOrDefault();
        }

        public void Remove(Company company)
        {
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
        }
    }
}