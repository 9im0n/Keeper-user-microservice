using UserMicroservice.Models.Database;
using UserMicroservice.Repositories.Interfaces;
using UserMicroservice.Services.Interfaces;
using UserMicroservice.Models.Exceptions;
using UserMicroservice.Models.DTO;

namespace UserMicroservice.Services.Implimentations
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IUserService _userService;


        public ProfileService(IProfileRepository profileRepository, IUserService userService)
        {
            _profileRepository = profileRepository;
            _userService = userService;
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
                UserId = user.Id,
                User = user
            };

            return _profileRepository.Create(newProfile);
        }


        public Profiles Update(ProfileDTO newProfile)
        { 
            var user = _userService.GetById(newProfile.UserId);

            if (user.ProfileId != newProfile.Id)
                throw new BadRequestException("Вы не являетесь обладателем этого профиля.");

            Profiles profile = _profileRepository.GetById(newProfile.Id);

            profile.Name = newProfile.Name;
            profile.AvatarUrl = newProfile.AvatarUrl;
            profile.Description = newProfile.Description;

            return _profileRepository.Update(profile);
        }
    }
}
