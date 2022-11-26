namespace API.Entities
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public ICollection<UserRoleAppUser>? UserRoles { get; set; }
    }
}
