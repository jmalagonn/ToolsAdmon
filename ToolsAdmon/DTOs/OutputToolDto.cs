using API.Entities;

namespace API.DTOs
{
    public class OutputToolDto
    {
        public int? OutputToolId { get; set; }
        public DateTime? OutputDateTime { get; set; } = DateTime.Now;
        public OutputToolState? OutputToolState { get; set; }
        public AppUserDto? Responsible { get; set; }
        public List<ToolDto>? Tools { get; set; }
    }
}
