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
    public class ToolsController : BaseApiController
    {
        private readonly IToolsRepository toolsRepository;
        private readonly IMapper mapper;
        private readonly ICompaniesRepository companiesRepository;
        private readonly int userId;

        public ToolsController(IToolsRepository toolsRepository, IMapper mapper, ICompaniesRepository companiesRepository)
        {
            this.toolsRepository = toolsRepository;
            this.mapper = mapper;
            this.companiesRepository = companiesRepository;
            this.userId = User.GetUserId();
        }

        [HttpPost]
        public async Task<ActionResult<ToolDto>> RegisterTool(ToolDto tool)
        {
            return Ok(this.mapper.Map<ToolDto>(await this.toolsRepository.RegisterTool(tool, this.userId)));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToolDto>>> GetToolsByCompany()
        {
            var company = await this.companiesRepository.GetCompanyByUserId(this.userId);
            return Ok(await this.toolsRepository.GetToolsByCompany(company.CompanyId));
        }
    }
}
