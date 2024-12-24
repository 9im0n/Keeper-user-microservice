using UserMicroservice.Models.Database;
using UserMicroservice.Repositories.Interfaces;
using UserMicroservice.Services.Interfaces;
using UserMicroservice.Models.Exceptions;

namespace UserMicroservice.Services.Implimentations
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;


        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }


        public Profiles GetById(Guid id)
        {
            Profiles profile = _profileRepository.GetById(id);

            if (profile == null)
                throw new NotFoundException("Профиля с таким Id не существует.");

            return profile;
        }


        public Profiles GetByUserId(Guid userId)
        {
            Profiles profile = _profileRepository.GetByUserId(userId);

            if (profile == null)
                throw new NotFoundException("Профиля для данного пользователя не существует.");

            return profile;
        }


        public Profiles Create(Users user)
        {
            Profiles existProfile = _profileRepository.GetByUserId(user.Id);

            if (existProfile != null)
                throw new AlreadyExistsException("Профиль для данного пользователя уже существует.");

            Profiles newProfile = new Profiles
            {
                Name = "",
                AvatarUrl = "",
                Description = "",
                UserId = user.Id
            };

            return _profileRepository.Create(newProfile);
        }


        public Profiles Update(Profiles profile)
        {
            return _profileRepository.Update(profile);
        }
    }
}
