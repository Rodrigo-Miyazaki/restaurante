using Restaurante.Core.Models;
using System.Threading.Tasks;

namespace Restaurante.Infrastructure.Repositories.Intefaces
{
    public interface IMealCompanyRepository
    {
        Task AddAsync(MealCompany mealCompany);
    }
}