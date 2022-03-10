using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Interfaces;
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
        public IActionResult Add([FromBody] Company company)
        {
            _companyApplicationService.Add(company);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            _companyApplicationService.Remove(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public Company GetById(int id)
        {
            return _companyApplicationService.GetById(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var response = await _companyApplicationService.GetAll(validFilter);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Company company)
        {
            _companyApplicationService.Update(company);
            return Ok();
        }
    }
}