using API.Entities;

namespace API.DTOs
{
    public class ToolDto
    {
        public int ToolId { get; set; }
        public string ToolName { get; set; }
        public string? ToolGuid { get; set; }
        public ToolState? ToolState { get; set; }
    }
}
