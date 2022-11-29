using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Repositories;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
            services.AddScoped<IToolsRepository, ToolsRepository>();
            services.AddScoped<IOutputToolsRepository, OutputToolsRepository>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: "ClientAppCors",
                                  policy =>
                                  {
                                      policy
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .WithOrigins("http://localhost:4200",
                                                     "http://localhost:4200");
                                  });
            });

            return services;
        }
    }
}
