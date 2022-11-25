using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly DataContext context;
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public CompaniesRepository(DataContext context, IUsersRepository usersRepository, IMapper mapper)
        {
            this.context = context;
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await this.context.Companies.ToListAsync();
        }

        public async Task<Company> GetCompany(int companyId)
        {
            return await this.context.Companies.FindAsync(companyId);
        }

        public async Task<Company> GetCompany(string companyName)
        {
            return await this.context.Companies.FirstOrDefaultAsync(x => x.CompanyName == companyName);
        }

        public async Task<Company> GetCompanyByUserId(int userId)
        {
            AppUser user = await this.usersRepository.GetUser(userId, true);
            return user.Company;
        }

        public async Task<Company> RegisterCompany(CompanyDto companyDto, int userId)
        {
            this.context.Companies.Add(this.mapper.Map<Company>(companyDto));
            await this.context.SaveChangesAsync();
            Company newCompany = await GetCompany(companyDto.CompanyName);
            await setCompanyToUser(userId, newCompany);

            return newCompany;            
        }

        private async Task<bool> setCompanyToUser(int userId, Company company)
        {
            AppUser user = await this.usersRepository.GetUser(userId);
            user.Company = company;
            this.context.Users.Update(user);

            return await this.context.SaveChangesAsync() > 0;
        }
    }
}
