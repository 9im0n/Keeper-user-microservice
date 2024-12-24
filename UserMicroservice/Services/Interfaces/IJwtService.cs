using UserMicroservice.Models.Database;
using UserMicroservice.Models.DTO;

namespace UserMicroservice.Services.Interfaces
{
    public interface IJwtService
    {
        public JwtResponse CreateJwtTokens(Users user);
        public JwtResponse UpdateJwtTokens(string refreshToken);
    }
}
