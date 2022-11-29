namespace API.Entities
{
    public class Tool
    {
        public int ToolId { get; set; }
        public string ToolName { get; set; }
        public string ToolGuid { get; set; } = Guid.NewGuid().ToString();
        public ToolState ToolState { get; set; }
        public int ToolStateId { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public ICollection<ToolOutputTool> OutputTools { get; set; }
    }
}