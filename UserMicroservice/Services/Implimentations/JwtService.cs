using UserMicroservice.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UserMicroservice.Repositories.Interfaces;
using UserMicroservice.Models.Database;
using UserMicroservice.Models.DTO;

namespace UserMicroservice.Services.Implimentations
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        private readonly IRefreshTokensRepository _refreshTokens;

        public JwtService(IConfiguration config, IRefreshTokensRepository refreshTokens)
        {
            _config = config;
            _refreshTokens = refreshTokens;
        }

        public JwtResponse CreateJwtTokens(Users user)
        {
            string accesToken = GenerateJwtToken(user);
            Guid refreshToken = GenerateRefreshToken();

            RefreshTokens oldToken = _refreshTokens.GetByUserId(user.Id);

            if (oldToken != null)
            {
                oldToken.Token = refreshToken;
                _refreshTokens.Update(oldToken);
            }
            else
            {
                _refreshTokens.Create(new RefreshTokens { Token = refreshToken, User = user, UserId = user.Id });
            }

            return new JwtResponse
            {
                accessToken = accesToken,
                refreshToken = refreshToken.ToString()
            };
        }

        public JwtResponse UpdateJwtTokens(string refreshToken) 
        {
            if (!Guid.TryParse(refreshToken, out Guid token))
                return null;

            RefreshTokens oldToken = _refreshTokens.GetByToken(token);
            oldToken.Token = GenerateRefreshToken();
            _refreshTokens.Update(oldToken);

            string accessToken = GenerateJwtToken(oldToken.User);

            return new JwtResponse
            {
                accessToken = accessToken,
                refreshToken = oldToken.Token.ToString()
            };
        }

        private string GenerateJwtToken(Users user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var token = new JwtSecurityToken(
                audience: _config["Jwt:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Guid GenerateRefreshToken()
        {
            while (true)
            {
                Guid newRefreshToken = Guid.NewGuid();

                var oldRefreshToken = _refreshTokens.GetByToken(newRefreshToken);

                if (oldRefreshToken == null) return newRefreshToken;
            }
        }
    }
}
