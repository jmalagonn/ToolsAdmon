namespace API.Entities
{
    public class ToolOutputTool
    {
        public Tool Tool { get; set; }
        public int ToolId { get; set; }
        public OutputTool OutputTool { get; set; }
        public int OutputToolId { get; set; }
    }
}
