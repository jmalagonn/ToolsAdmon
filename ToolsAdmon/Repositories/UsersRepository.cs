using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public UsersRepository(
            DataContext context, 
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await this.context.Users.ToListAsync();
        }

        public async Task<bool> DeleteUser(int userId)
        {
            this.context.Users.Remove(await GetUser(userId));

            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUser(string email)
        {
            this.context.Users.Remove(await GetUser(email));

            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<AppUser> GetUser(int userId, bool incCompany = false)
        {
            return !incCompany
                ? await this.context.Users.FindAsync(userId)
                : await this.context.Users.Include(x => x.Company).FirstAsync(x => x.UserId == userId);
        }

        public async Task<AppUser> GetUser(string email)
        {
            return await this.context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<AppUser> RegisterEmployee(EmployeeDto employeeDto, int adminUserId)
        {
            var adminUser = await this.context.Users.FindAsync(adminUserId);
            var employee = this.mapper.Map<AppUser>(employeeDto);

            employee.CompanyId = adminUser.CompanyId;

            this.context.Users.Add(employee);
            await this.context.SaveChangesAsync();

            return employee;      
        }

        public async Task<IEnumerable<AppUser>> GetEmployees(int adminUserId)
        {
            var adminUser = await this.context.Users.FindAsync(adminUserId);

            return await this.context.Users
                .Include(x => x.Company)
                .Where(x => 
                    x.CompanyId == adminUser.CompanyId &&
                    x.UserId != adminUserId)
                .ToListAsync();
        }
    }
}
