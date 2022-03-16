using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Interfaces.Services;
using Restaurante.Core.Models;
using System.Threading.Tasks;

namespace Restaurante.Api.Controllers
{
    [Route("api/mealcompany")]
    [ApiController]
    public class MealCompanyController : ControllerBase
    {
        private readonly IMealCompanyApplicationService _mealCompanyApplicationService;

        public MealCompanyController(IMealCompanyApplicationService mealCompanyApplicationService)
        {
            _mealCompanyApplicationService = mealCompanyApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MealCompany mealCompany)
        {
            await _mealCompanyApplicationService.AddAsync(mealCompany);
            return Ok();
        }
    }
}