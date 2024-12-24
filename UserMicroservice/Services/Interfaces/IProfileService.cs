using UserMicroservice.Models.Database;
using UserMicroservice.Models.DTO;

namespace UserMicroservice.Services.Interfaces
{
    public interface IProfileService
    {
        public Profiles GetById(Guid id);
        public Profiles GetByUserId(Guid id);
        public Profiles Create(Users user);
        public Profiles Update(ProfileDTO newProfile);
    }
}
