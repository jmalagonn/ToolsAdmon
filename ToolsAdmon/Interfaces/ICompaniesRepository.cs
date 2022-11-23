using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICompaniesRepository
    {
        public Task<Company> GetCompany(int companyId);
        public Task<Company> GetCompany(string companyName);
        public Task<Company> GetCompanyByUserId(int userId);
        public Task<Company> RegisterCompany(CompanyDto companyDto, int userId);
    }
}
