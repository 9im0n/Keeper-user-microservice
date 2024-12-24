namespace UserMicroservice.Models.Database
{
    public class RefreshTokens : BaseModel
    {
        public Guid Token { get; set; }
        public Guid UserId { get; set; }
        public Users User { get; set; }
    }
}
