using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
        public ICollection<UserRole>? UserRoles { get; set; }
    }
}
