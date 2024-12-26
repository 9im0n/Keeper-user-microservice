using UserMicroservice.Models.Database;
using UserMicroservice.Models.DTO;

namespace UserMicroservice.Services.Interfaces
{
    public interface IAuthService
    {
        public Users Register(AuthRequestDTO request);
        public Users Login(AuthRequestDTO request);
    }
}
