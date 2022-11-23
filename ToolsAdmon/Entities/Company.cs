namespace API.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set;}
        public ICollection<AppUser> Users { get; set; }
        public ICollection<Tool> Tools { get; set; }
    }
}
