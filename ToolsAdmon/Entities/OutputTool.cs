namespace API.Entities
{
    public class OutputTool
    {
        public int OutputToolId { get; set; }
        public DateTime OutputDateTime { get; set; } = DateTime.Now;
        public OutputToolState OutputToolState { get; set; }
        public int OutputToolStateId { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public AppUser Responsible { get; set; }
        public int ResponsibleId { get; set; }
        public AppUser CreatedBy { get; set; }
        public int CreatedById { get; set; }
        public ICollection<ToolOutputTool> Tools { get; set; }
    }
}
