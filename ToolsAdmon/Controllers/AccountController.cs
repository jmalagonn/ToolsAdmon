using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Services;
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
        public async Task<ActionResult<AppUserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Email.ToLower())) return BadRequest("El email ya ha sido registrado");

            var user = this.mapper.Map<AppUser>(registerDto);

            using var hmac = new HMACSHA512();

            user.Email = registerDto.Email.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
            user.PasswordSalt = hmac.Key;

            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            return new AppUserDto
            {
                Name = user.Name,
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUserDto>> Login(LoginDto loginDto)
        {
            const string INVALID_CREDENTIALS = "Invalid email or password";
            var user = await this.context.Users.SingleOrDefaultAsync(user => user.Email == loginDto.Email);

            if (user == null) return Unauthorized(INVALID_CREDENTIALS);

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized(INVALID_CREDENTIALS);
            }

            return new AppUserDto
            {
                Name = user.Name,
                Email = user.Email,
                Token = this.tokenService.CreateToken(user),
            };
        }
        private async Task<bool> UserExists(string email)
        {
            return await this.context.Users.AnyAsync(user => user.Email == email);
        }
    }
}
