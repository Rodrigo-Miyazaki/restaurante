using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Interfaces.Services;
using Restaurante.Core.Models;
using System.Threading.Tasks;

namespace Restaurante.Api.Controllers
{
    [Route("api/mealfood")]
    [ApiController]
    public class MealFoodController : ControllerBase
    {
        private readonly IMealFoodApplicationService _mealFoodApplicationService;

        public MealFoodController(IMealFoodApplicationService mealFoodApplicationService)
        {
            _mealFoodApplicationService = mealFoodApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MealFood mealFood)
        {
            await _mealFoodApplicationService.AddAsync(mealFood);
            return Ok();
        }
    }
}