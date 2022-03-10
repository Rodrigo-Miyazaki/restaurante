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

        public void Add(Company company) => _companyRepository.Add(company);

        public async Task<List<Company>> GetAll(PaginationFilter filter) => await _companyRepository.GetAll(filter);

        public Company GetById(int id) => _companyRepository.GetById(id);

        public void Remove(int id)
        {
            var company = new Company { Id = id };
            _companyRepository.Remove(company);
        }

        public void Update(Company company) => _companyRepository.Update(company);
    }
}