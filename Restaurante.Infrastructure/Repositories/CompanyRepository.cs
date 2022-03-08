using Restaurante.Core.Models;
using Restaurante.Infrastructure.EntityFramework;

namespace Restaurante.Infrastructure.Repositories
{
    public interface ICompanyRepository
    {
        void Add(Company company);
    }

    public class CompanyRepository : ICompanyRepository
    {
        private readonly RestauranteContext _context;

        public CompanyRepository(RestauranteContext context) => _context = context;

        public void Add(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }
    }
}