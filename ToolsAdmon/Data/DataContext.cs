using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserRoleAppUser> UserRolesAppUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<ToolState> ToolStates { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRoleAppUser>()
                .HasKey(k => new { k.UserRoleId, k.AppUserId });

            builder.Entity<AppUser>()
                .HasIndex(u => u.Email).IsUnique();

            builder.Entity<Tool>()
                .HasIndex(u => u.ToolGuid).IsUnique();

            builder.Entity<ToolState>().HasData(new List<ToolState> {
                new ToolState{ToolStateId=1,ToolStateName="Disponible"},
                new ToolState{ToolStateId=2,ToolStateName="Con novedad"},
                new ToolState{ToolStateId=3,ToolStateName="Prestado"},
            });

            builder.Entity<UserRole>().HasData(new List<UserRole> {
                new UserRole{UserRoleId=1,UserRoleName="AppAdmin"},
                new UserRole{UserRoleId=2,UserRoleName="CompanyAdmin"},
                new UserRole{UserRoleId=3,UserRoleName="CompanyEmployee"},
            });
        }
    }
}
