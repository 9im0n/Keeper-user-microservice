namespace UserMicroservice.Models.DTO
{
    public class ProfileDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}
