using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IToolsRepository
    {
        public Task<Tool> RegisterTool(ToolDto tool, int userId);
    }
}
