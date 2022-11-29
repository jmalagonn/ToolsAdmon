using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface IOutputToolsRepository
    {
        Task<IEnumerable<OutputTool>> GetOutputTools(int userId);
        Task<OutputTool> GetOutputTool(int outputToolId);
        Task<List<Tool>> GetToolsOutputTool(int outputToolId);
        Task<OutputTool> RegisterOutputTool(OutputToolDto outputToolDto, int creatorId);
        Task<bool> SaveToolsIntoOutputTool(OutputTool outputTool, List<Tool> tools);
    }
}
