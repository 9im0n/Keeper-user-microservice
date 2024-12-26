using UserMicroservice.Services.Interfaces;
using UserMicroservice.Models.Database;
using UserMicroservice.Models.Exceptions;
using UserMicroservice.Models.DTO;


namespace UserMicroservice.Services.Implimentations
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _usersService;
        private readonly IProfileService _profileService;

        public AuthService(IUserService usersService, IProfileService profileService)
        {
            _usersService = usersService;
            _profileService = profileService;
        }

        private bool CheckPassword(Users user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }


        public Users Register(AuthRequestDTO request)
        {
            Users newUser = _usersService.Create(new Users
            {
                Email = request.Email,
                Password = HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow,
            });

            var profile = _profileService.Create(newUser);
            newUser.Profile = profile;
            newUser.ProfileId = profile.Id;
            _usersService.Update(newUser);

            return newUser;
        }


        public Users Login(AuthRequestDTO request)
        {
            Users user = _usersService.GetByEmail(request.Email);

            if (!CheckPassword(user, request.Password))
                throw new BadRequestException("Неверный email или пароль.");

            return user;
        }
    }
}
