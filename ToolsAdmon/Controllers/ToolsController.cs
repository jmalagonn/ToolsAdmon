using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ToolsController : BaseApiController
    {
        private readonly IToolsRepository toolsRepository;
        private readonly IMapper mapper;

        public ToolsController(IToolsRepository toolsRepository, IMapper mapper)
        {
            this.toolsRepository = toolsRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ToolDto>> RegisterTool(ToolDto tool)
        {
            int userId = User.GetUserId();

            return Ok(this.mapper.Map<ToolDto>(await this.toolsRepository.RegisterTool(tool, userId)));
        }
    }
}
