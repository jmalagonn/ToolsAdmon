using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<EmployeeDto, AppUser>();
            CreateMap<AppUser, EmployeeDto>();

            CreateMap<CompanyDto, Company>();
            CreateMap<Company, CompanyDto>();

            CreateMap<ToolDto, Tool>();
            CreateMap<Tool, ToolDto>();
        }
    }
}
