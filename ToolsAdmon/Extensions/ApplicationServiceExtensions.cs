using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Repositories;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
            services.AddScoped<IToolsRepository, ToolsRepository>();
            services.AddScoped<IOutputToolsRepository, OutputToolsRepository>();

            if (builder.Environment.IsDevelopment())
            {
                services.AddDbContext<DataContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
            } 
            else
            {
                services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
            }

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
