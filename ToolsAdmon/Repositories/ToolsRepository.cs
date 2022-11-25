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
            return await this.context.Tools.Where(x => x.CompanyId == companyId).ToListAsync();
        }

        public async Task<Tool> RegisterTool(ToolDto tool, int userId)
        {
            Company company = await this.companiesRepository.GetCompanyByUserId(userId);

            Tool newTool = this.mapper.Map<Tool>(tool);

            newTool.Company = company;
            newTool.CompanyId = company.CompanyId;

            await this.context.Tools.AddAsync(newTool);

            return newTool;
        }
    }
}
