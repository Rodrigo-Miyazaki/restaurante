using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Interfaces;
using Restaurante.Application.Services;
using Restaurante.Core.Models;

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

        [HttpGet]
        public Food GetById(int id)
        {
            return _foodApplicationService.GetById(id);
        }

        [HttpPut]
        public IActionResult Update(Food food)
        {
            _foodApplicationService.Update(food);
            return Ok();
        }
    }
}