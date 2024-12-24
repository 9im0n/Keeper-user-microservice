using UserMicroservice.Services.Interfaces;
using UserMicroservice.Models.Database;
using UserMicroservice.Models.Exceptions;
using UserMicroservice.Models.DTO;


namespace UserMicroservice.Services.Implimentations
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _usersService;

        public AuthService(IUserService usersService)
        {
            _usersService = usersService;
        }


        public Users Register(AuthRequest request)
        {
            Users newUser = _usersService.Create(new Users
            {
                Email = request.Email,
                Password = HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow,
            });

            return newUser;
        }


        public Users Login(AuthRequest request)
        {
            Users user = _usersService.GetByEmail(request.Email);

            if (!CheckPassword(user, request.Password))
                throw new BadRequestException("Неверный email или пароль.");

            return user;
        }


        private bool CheckPassword(Users user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
