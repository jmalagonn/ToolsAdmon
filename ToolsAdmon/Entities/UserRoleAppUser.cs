namespace API.Entities
{
    public class UserRoleAppUser
    {
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public UserRole UserRole { get; set; }
        public int UserRoleId { get; set; }
    }
}
