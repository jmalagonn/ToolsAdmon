using API.Entities;
using API.Helpers;
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
        public DbSet<OutputTool> OutputTools { get; set; }
        public DbSet<OutputToolState> OutputToolStates { get; set; }
        public DbSet<ToolOutputTool> ToolOutputTools { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRoleAppUser>()
                .HasKey(k => new { k.UserRoleId, k.AppUserId });

            builder.Entity<ToolOutputTool>()
                .HasKey(k => new { k.ToolId, k.OutputToolId });

            builder.Entity<AppUser>()
                .HasIndex(u => u.Email).IsUnique();

            builder.Entity<Tool>()
                .HasIndex(u => u.ToolGuid).IsUnique();

            builder.Entity<ToolState>().HasData(AppConstants.INITIAL_TOOL_STATES);

            builder.Entity<UserRole>().HasData(AppConstants.INITIAL_USER_ROLES);

            builder.Entity<OutputToolState>().HasData(AppConstants.INITIAL_OUTPUT_TOOL_STATES);
        }
    }
}
