namespace API.Entities
{
    public class ToolOutput
    {
        public int ToolOutputId { get; set; }
        public DateTime OutputDateTime { get; set; }
        public AppUser OutputRecorder { get; set; }
        public int OutputRecorderId { get; set; }
        public AppUser Responsible { get; set; }
        public int ResponsibleId { get; set; }
        public ICollection<Tool> Tools { get; set; }
    }
}
