using Restaurante.Core.Models;
using Restaurante.Infrastructure.Repositories;

namespace Restaurante.Application.Services
{
    public interface ICompanyApplicationService
    {
        public void Add(Company company);
    }

    public class CompanyApplicationService : ICompanyApplicationService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyApplicationService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void Add(Company company) => _companyRepository.Add(company);
    }
}