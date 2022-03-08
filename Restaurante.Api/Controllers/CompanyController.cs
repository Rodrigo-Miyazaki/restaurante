using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Services;
using Restaurante.Core.Models;

namespace Restaurante.Api.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyApplicationService _companyApplicationService;

        public CompanyController(ICompanyApplicationService companyApplicationService)
        {
            _companyApplicationService = companyApplicationService;
        }

        [HttpPost]
        public IActionResult Add(Company company)
        {
            _companyApplicationService.Add(company);
            return Ok();
        }
    }
}