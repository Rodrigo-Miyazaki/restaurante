using Restaurante.Application.Interfaces.Services;
using Restaurante.Core.Models;
using Restaurante.Infrastructure.Repositories.Intefaces;
using System.Threading.Tasks;

namespace Restaurante.Application.Services
{
    public class MealCompanyApplicationService : IMealCompanyApplicationService
    {
        private readonly IMealCompanyRepository _mealCompanyRepository;

        public MealCompanyApplicationService(IMealCompanyRepository mealCompanyRepository)
        {
            _mealCompanyRepository = mealCompanyRepository;
        }

        public Task AddAsync(MealCompany mealCompany) => _mealCompanyRepository.AddAsync(mealCompany);
    }
}