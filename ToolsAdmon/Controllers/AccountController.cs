using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;

        public AccountController(DataContext context, IMapper mapper, ITokenService tokenService)
        {
            this.context = context;
            this.mapper = mapper;
            this.tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Email.ToLower())) return BadRequest("El email ya ha sido registrado");

            var user = this.mapper.Map<User>(registerDto);

            using var hmac = new HMACSHA512();

            user.Email = registerDto.Email.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
            user.PasswordSalt = hmac.Key;

            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            return new UserDto
            {
                Name = user.Name,
                Token = tokenService.CreateToken(user)
            };
        }
        private async Task<bool> UserExists(string email)
        {
            return await this.context.Users.AnyAsync(user => user.Email == email);
        }
    }
}
