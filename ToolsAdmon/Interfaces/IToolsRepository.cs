using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IToolsRepository
    {
        public Task<Tool> RegisterTool(ToolDto tool, int userId);
        public Task<IEnumerable<Tool>> GetToolsByCompany(int companyId);
        public Task<IEnumerable<Tool>> GetAvailableTools(int companyId);
        public Task SetToolState(Tool tool, int toolStateId);
    }
}
