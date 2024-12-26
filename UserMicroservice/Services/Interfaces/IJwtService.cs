using UserMicroservice.Models.Database;
using UserMicroservice.Models.DTO;

namespace UserMicroservice.Services.Interfaces
{
    public interface IJwtService
    {
        public JwtResponseDTO CreateJwtTokens(Users user);
        public JwtResponseDTO UpdateJwtTokens(string refreshToken);
    }
}
