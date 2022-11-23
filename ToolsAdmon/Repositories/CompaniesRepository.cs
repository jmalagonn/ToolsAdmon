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
            AppUser user = await this.usersRepository.GetUser(userId);

            await this.context.Companies.AddAsync(this.mapper.Map<Company>(companyDto));

            Company newCompany = await this.GetCompany(companyDto.CompanyName);

            user.Company = newCompany;

            this.context.Users.Update(user);
            this.context.SaveChangesAsync();

            return newCompany;            
        }
    }
}
