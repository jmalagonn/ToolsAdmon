using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public UsersController(IUsersRepository usersRepository, IMapper mapper)
        {
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return Ok(await this.usersRepository.GetUsers());
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult<bool>> DeleteUserByEmail(string email)
        {  
            return Ok(await this.usersRepository.DeleteUser(email));
        }

        [HttpPost("addEmployee")]
        public async Task<ActionResult<EmployeeDto>> RegisterEmployee(EmployeeDto employeeDto)
        {
            var userId = User.GetUserId();
            var employee = await this.usersRepository.RegisterEmployee(employeeDto, userId);

            return Ok(this.mapper.Map<EmployeeDto>(employee));
        }

        [HttpGet("employees")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var userId = User.GetUserId();
            var employees = await this.usersRepository.GetEmployees(userId);

            return Ok(this.mapper.Map<List<EmployeeDto>>(employees));
        }
    }
}
