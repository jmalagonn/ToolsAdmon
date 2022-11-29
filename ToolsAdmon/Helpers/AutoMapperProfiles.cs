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
            CreateMap<AppUserDto, AppUser>();

            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUser, EmployeeDto>();

            CreateMap<CompanyDto, Company>();
            CreateMap<Company, CompanyDto>();

            CreateMap<ToolDto, Tool>();
            CreateMap<Tool, ToolDto>();

            CreateMap<OutputTool, OutputToolDto>();
            CreateMap<OutputToolDto, OutputTool>();
        }
    }
}
