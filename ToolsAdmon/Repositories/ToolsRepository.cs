using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Repositories
{
    public class ToolsRepository : IToolsRepository
    {
        private readonly DataContext context;
        private readonly ICompaniesRepository companiesRepository;
        private readonly IMapper mapper;

        public ToolsRepository(DataContext context, ICompaniesRepository companiesRepository, IMapper mapper)
        {
            this.context = context;
            this.companiesRepository = companiesRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<Tool>> GetToolsByCompany(int companyId)
        {
            return await this.context.Tools
                .Include(x => x.ToolState)
                .Where(x => x.CompanyId == companyId)
                .ToListAsync();
        }
        public async Task<Tool> RegisterTool(ToolDto tool, int userId)
        {
            Company company = await this.companiesRepository.GetCompanyByUserId(userId);
            ToolState availableToolState = await this.context.ToolStates.SingleAsync(x => x.ToolStateName == "Disponible");

            Tool newTool = this.mapper.Map<Tool>(tool);

            newTool.Company = company;
            newTool.CompanyId = company.CompanyId;
            newTool.ToolStateId = availableToolState.ToolStateId;
            newTool.ToolGuid = Guid.NewGuid().ToString();

            this.context.Tools.Add(newTool);
            await this.context.SaveChangesAsync();

            return newTool;
        }
        public async Task<IEnumerable<Tool>> GetAvailableTools(int companyId)
        {
            ToolState availableToolState = await this.context.ToolStates.SingleAsync(x => x.ToolStateName == "Disponible");

            return await this.context.Tools
                .Include(x => x.ToolState)
                .Where(x => 
                    x.CompanyId == companyId && 
                    x.ToolStateId == availableToolState.ToolStateId)
                .ToListAsync();
        }
    }
}
