using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Services.Interfaces;
using Restaurante.Core.Models;
using System.Threading.Tasks;

namespace Restaurante.Api.Controllers
{
    [Route("api/meal")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IBaseApplicationService<Meal> _mealApplicationService;

        public MealController(IBaseApplicationService<Meal> mealApplicationService)
        {
            _mealApplicationService = mealApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Meal meal)
        {
            await _mealApplicationService.AddAsync(meal);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            await _mealApplicationService.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var meal = await _mealApplicationService.GetByIdAsync(id);
            return Ok(meal);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var response = await _mealApplicationService.GetAllAsync(validFilter);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Meal meal)
        {
            await _mealApplicationService.UpdateAsync(meal);
            return Ok();
        }
    }
}