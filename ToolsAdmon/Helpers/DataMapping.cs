using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class DataMapping
    {
        private readonly IMapper mapper;

        public DataMapping(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public OutputToolDto OutputToolToDto(OutputTool outputTool)
        {
            List<Tool> tools = new List<Tool>();

            foreach(var item in outputTool.Tools)
            {
                tools.Add(item.Tool);
            }

            return new OutputToolDto
            {
                OutputToolId = outputTool.OutputToolId,
                OutputDateTime = outputTool.OutputDateTime,
                OutputToolState = outputTool.OutputToolState,
                Responsible = this.mapper.Map<AppUserDto>(outputTool.Responsible),
                Tools = this.mapper.Map<List<ToolDto>>(tools)
            };
        }
    }
}
