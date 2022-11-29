namespace API.DTOs
{
    public class AppUserDto
    {
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? Token { get; set; }
        public string? Email { get; set; }
        public CompanyDto? Company { get; set; }
    }
}
