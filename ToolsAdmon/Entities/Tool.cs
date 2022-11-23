namespace API.Entities
{
    public class Tool
    {
        public int ToolId { get; set; }
        public string ToolName { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
