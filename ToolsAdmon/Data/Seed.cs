using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (await context.Companies.AnyAsync() || 
                await context.Users.AnyAsync() || 
                await context.Tools.AnyAsync()) return;

            var seedData = await System.IO.File.ReadAllTextAsync("Data/SeedData/CompaniesSeedData.json");
            var data = JsonSerializer.Deserialize<List<Company>>(seedData);

            foreach (var company in data)
            {
                context.Companies.Add(company);

                foreach (var account in company.Users)
                {
                    using var hmac = new HMACSHA512();

                    account.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                    account.PasswordSalt = hmac.Key;

                    context.Users.Add(account);
                }

                foreach(var tool in company.Tools)
                {
                    tool.ToolGuid = Guid.NewGuid().ToString();

                    context.Tools.Add(tool);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
