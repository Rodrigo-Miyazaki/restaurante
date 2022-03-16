using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Services.Interfaces;
using Restaurante.Core.Models;
using System.Threading.Tasks;

namespace Restaurante.Api.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IBaseApplicationService<Company> _companyApplicationService;

        public CompanyController(IBaseApplicationService<Company> companyApplicationService)
        {
            _companyApplicationService = companyApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Company company)
        {
            await _companyApplicationService.AddAsync(company);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            await _companyApplicationService.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyApplicationService.GetByIdAsync(id);
            return Ok(company);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var response = await _companyApplicationService.GetAllAsync(validFilter);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Company company)
        {
            await _companyApplicationService.UpdateAsync(company);
            return Ok();
        }
    }
}