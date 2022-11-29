using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class OutputToolsRepository : IOutputToolsRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly IToolsRepository toolsRepository;
        private readonly ICompaniesRepository companiesRepository;

        public OutputToolsRepository(
            DataContext context, 
            IMapper mapper, 
            IToolsRepository toolsRepository,
            ICompaniesRepository companiesRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.toolsRepository = toolsRepository;
            this.companiesRepository = companiesRepository;
        }

        public async Task<OutputTool> GetOutputTool(int outputToolId)
        {
            var toolsOutputTool = await this.context.ToolOutputTools
                .Include(x => x.Tool)
                .Where(x => x.OutputToolId == outputToolId)
                .ToListAsync();

            return await this.context.OutputTools
                .Include(x => x.Tools)
                .Include(x => x.Responsible)
                .Include(x => x.OutputToolState)
                .SingleAsync(x => x.OutputToolId == outputToolId);
        }

        public async Task<IEnumerable<OutputTool>> GetOutputTools(int userId)
        {
            Company company = await this.companiesRepository.GetCompanyByUserId(userId);

            IEnumerable<OutputTool> outputTools = await this.context.OutputTools
                .Include(x => x.Tools)
                .Include(x => x.OutputToolState)
                .Include(x => x.Responsible)
                .Where(x => x.CompanyId == company.CompanyId)
                .ToListAsync();

            return outputTools;
        }

        public async Task<List<Tool>> GetToolsOutputTool(int outputToolId)
        {
            return await this.context.ToolOutputTools
                .Include(x => x.Tool)
                .Where(x => x.OutputToolId == outputToolId)
                .Select(x => x.Tool)
                .ToListAsync();
        }

        public async Task<OutputTool> RegisterOutputTool(OutputToolDto outputToolDto, int creatorId)
        {
            OutputToolState avaiblableOutputToolState = await this.context.OutputToolStates
                .SingleAsync(x => x.OutputToolStateName == "Open");
            List<Tool> tools = this.mapper.Map<List<Tool>>(outputToolDto.Tools);
            AppUser responsible = this.mapper.Map<AppUser>(outputToolDto.Responsible);
            Company company = await this.companiesRepository.GetCompanyByUserId(creatorId);

            var outputTool = new OutputTool
            {
                CreatedById = creatorId,
                CompanyId = company.CompanyId,
                OutputToolStateId = avaiblableOutputToolState.OutputToolStateId,
                ResponsibleId = responsible.UserId,
            };

            this.context.OutputTools.Add(outputTool);

            await this.context.SaveChangesAsync();
            await SaveToolsIntoOutputTool(outputTool, tools);

            return await GetOutputTool(outputTool.OutputToolId);
        }

        public async Task<bool> SaveToolsIntoOutputTool(OutputTool outputTool, List<Tool> tools)
        {
            ToolState LentToolState = await this.context.ToolStates.SingleAsync(x => x.ToolStateName == "Prestado");

            foreach(var tool in tools)
            {
                this.context.ToolOutputTools.Add(new ToolOutputTool
                {
                    OutputToolId = outputTool.OutputToolId,
                    ToolId = tool.ToolId,
                });

                tool.ToolState = LentToolState;
                tool.CompanyId = outputTool.CompanyId;

                this.context.Tools.Update(tool);
            }

            return await this.context.SaveChangesAsync() > 0;
        }
    }
}
