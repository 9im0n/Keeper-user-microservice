using UserMicroservice.Models.Database;
using UserMicroservice.Models.DTO;

namespace UserMicroservice.Services.Interfaces
{
    public interface IAuthService
    {
        public Users Register(AuthRequest request);
        public Users Login(AuthRequest request);
    }
}
