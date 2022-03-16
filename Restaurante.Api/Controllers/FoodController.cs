using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Services.Interfaces;
using Restaurante.Core.Models;
using System.Threading.Tasks;

namespace Restaurante.Api.Controllers
{
    [Route("api/food")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IBaseApplicationService<Food> _foodApplicationService;

        public FoodController(IBaseApplicationService<Food> foodApplicationService)
        {
            _foodApplicationService = foodApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Food food)
        {
            await _foodApplicationService.AddAsync(food);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            await _foodApplicationService.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var food = await _foodApplicationService.GetByIdAsync(id);
            return Ok(food);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var response = await _foodApplicationService.GetAllAsync(validFilter);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Food food)
        {
            await _foodApplicationService.UpdateAsync(food);
            return Ok();
        }
    }
}