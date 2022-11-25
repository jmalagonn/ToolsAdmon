using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class CompaniesController : BaseApiController
    {
        private readonly ICompaniesRepository companiesRepository;
        private readonly IMapper mapper;
        private readonly int userId;

        public CompaniesController(ICompaniesRepository companiesRepository, IMapper mapper)
        {
            this.companiesRepository = companiesRepository;
            this.mapper = mapper;
        }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies() 
        {
            return Ok(await this.companiesRepository.GetCompanies());
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDto>> RegisterCompany(CompanyDto companyDto)
        {
            int userId = User.GetUserId();
            Company newCompany = await this.companiesRepository.RegisterCompany(companyDto, userId);

            return Ok(this.mapper.Map<CompanyDto>(newCompany));
        }

        [HttpGet("info")]
        public async Task<ActionResult<CompanyDto>> GetCompanyInfo()
        {
            int userId = User.GetUserId();
            Company company = await this.companiesRepository.GetCompanyByUserId(userId);

            return Ok(this.mapper.Map<CompanyDto>(company));
        }
    }
}
