namespace API.Entities
{
    public class Tool
    {
        public int ToolId { get; set; }
        public string ToolName { get; set; }
        public string ToolGuid { get; set; } = Guid.NewGuid().ToString();
        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}