using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Interfaces;
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
        public IActionResult Add(Food food)
        {
            _foodApplicationService.Add(food);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            _foodApplicationService.Remove(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public Food GetById([FromRoute] int id)
        {
            return _foodApplicationService.GetById(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var response = await _foodApplicationService.GetAll(validFilter);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(Food food)
        {
            _foodApplicationService.Update(food);
            return Ok();
        }
    }
}