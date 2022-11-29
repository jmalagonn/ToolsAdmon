using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class OutputToolsController : BaseApiController
    {
        private readonly IOutputToolsRepository outputToolsRepository;
        private readonly IMapper mapper;

        public OutputToolsController(IOutputToolsRepository outputToolsRepository, IMapper mapper)
        {
            this.outputToolsRepository = outputToolsRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutputToolDto>>> GetOutputTools()
        {
            IEnumerable<OutputTool> outputTools = await this.outputToolsRepository.GetOutputTools(User.GetUserId());
            List<OutputToolDto> result = new List<OutputToolDto>();

            foreach(var item in outputTools)
            {
                result.Add(new DataMapping(this.mapper).OutputToolToDto(item));
            }

            return Ok(result);
        }

        [HttpGet("{outputToolId}")]
        public async Task<ActionResult<OutputToolDto>> GetOutputTool(int outputToolId)
        {
            OutputTool outputTool = await this.outputToolsRepository.GetOutputTool(outputToolId);
            OutputToolDto result = new DataMapping(this.mapper).OutputToolToDto(outputTool);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<OutputToolDto>> RegisterOutputTool(OutputToolDto outputToolDto)
        {
            OutputTool outputTool = await this.outputToolsRepository.RegisterOutputTool(outputToolDto, User.GetUserId());
            OutputToolDto result = new DataMapping(this.mapper).OutputToolToDto(outputTool);

            return Ok(result);
        }
    }
}
