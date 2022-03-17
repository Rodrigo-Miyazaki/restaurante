using Restaurante.Core.Models;
using System.Threading.Tasks;

namespace Restaurante.Application.Interfaces.Services
{
    public interface IMealFoodApplicationService
    {
        Task AddAsync(MealFood mealFood);
    }
}