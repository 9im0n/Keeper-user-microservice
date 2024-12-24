namespace UserMicroservice.Models.DTO
{
    public class JwtResponse
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }
}
