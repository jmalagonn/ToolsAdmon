using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUsersRepository usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
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
    }
}
