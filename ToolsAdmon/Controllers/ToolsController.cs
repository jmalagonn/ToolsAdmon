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

        public ToolsController(IToolsRepository toolsRepository, IMapper mapper, ICompaniesRepository companiesRepository)
        {
            this.toolsRepository = toolsRepository;
            this.mapper = mapper;
            this.companiesRepository = companiesRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ToolDto>> RegisterTool(ToolDto tool)
        {
            int userId = User.GetUserId();

            return Ok(this.mapper.Map<ToolDto>(await this.toolsRepository.RegisterTool(tool, userId)));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToolDto>>> GetToolsByCompany()
        {
            int userId = User.GetUserId();
            var company = await this.companiesRepository.GetCompanyByUserId(userId);
            var tools = await this.toolsRepository.GetToolsByCompany(company.CompanyId);

            return Ok(this.mapper.Map<List<ToolDto>>(tools));
        }
    }
}
