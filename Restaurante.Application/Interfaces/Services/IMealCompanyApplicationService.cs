using Restaurante.Core.Models;
using System.Threading.Tasks;

namespace Restaurante.Application.Interfaces.Services
{
    public interface IMealCompanyApplicationService
    {
        Task AddAsync(MealCompany mealCompany);
    }
}