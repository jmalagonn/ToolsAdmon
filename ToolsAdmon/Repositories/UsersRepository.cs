using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext context;

        public UsersRepository(DataContext context)
        {
            this.context = context;
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
    }
}
