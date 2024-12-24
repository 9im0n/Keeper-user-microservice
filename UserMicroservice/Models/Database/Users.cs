namespace UserMicroservice.Models.Database
{
    public class Users : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }

        public Guid ProfileId { get; set; }
        public Profiles Profile { get; set; }
    }
}
