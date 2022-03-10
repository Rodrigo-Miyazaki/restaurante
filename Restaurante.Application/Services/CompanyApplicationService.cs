using Restaurante.Application.Interfaces;
using Restaurante.Core.Models;
using Restaurante.Infrastructure.Repositories.Intefaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurante.Application.Services
{
    public class CompanyApplicationService : IBaseApplicationService<Company>
    {
        private readonly IBaseRepository<Company> _companyRepository;

        public CompanyApplicationService(IBaseRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task AddAsync(Company company) => await _companyRepository.AddAsync(company);

        public async Task<List<Company>> GetAllAsync(PaginationFilter filter) => await _companyRepository.GetAllAsync(filter);

        public async Task<Company> GetByIdAsync(int id) => await _companyRepository.GetByIdAsync(id);

        public async Task RemoveAsync(int id)
        {
            var company = new Company { Id = id };
            await _companyRepository.RemoveAsync(company);
        }

        public async Task UpdateAsync(Company company) => await _companyRepository.UpdateAsync(company);
    }
}