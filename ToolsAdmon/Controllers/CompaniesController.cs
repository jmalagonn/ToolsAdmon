using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CompaniesController : BaseApiController
    {
        private readonly ICompaniesRepository companiesRepository;

        public CompaniesController(ICompaniesRepository companiesRepository)
        {
            this.companiesRepository = companiesRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Company>> RegisterCompany(CompanyDto companyDto)
        {
            int userId = User.GetUserId();

            return Ok(await this.companiesRepository.RegisterCompany(companyDto, userId));
        }
    }
}
