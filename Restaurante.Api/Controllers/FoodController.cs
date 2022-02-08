using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Models;

namespace Restaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(Food food)
        {
            return Ok();
        }
    }
}