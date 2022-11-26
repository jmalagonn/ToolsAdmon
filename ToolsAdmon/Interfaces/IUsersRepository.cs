using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUsersRepository
    {
        public Task<IEnumerable<AppUser>> GetUsers();
        public Task<AppUser> GetUser(int userId, bool incCompany = false);
        public Task<AppUser> GetUser(string email);
        public Task<bool> DeleteUser(int userId); 
        public Task<bool> DeleteUser(string email);
        public Task<AppUser> RegisterEmployee(EmployeeDto employeeDto, int adminUserId);
        public Task<IEnumerable<AppUser>> GetEmployees(int adminUserId);
    }
}
