using UserMicroservice.Repositories.Interfaces;
using UserMicroservice.Services.Interfaces;
using UserMicroservice.Models.Database;
using UserMicroservice.Models.Exceptions;

namespace UserMicroservice.Services.Implimentations
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _userRepository;

        public UserService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        

        public ICollection<Users> GetAll()
        {
            return _userRepository.GetAll();
        }


        public Users GetById(Guid id)
        {
            Users user = _userRepository.GetById(id);

            if (user == null)
                throw new NotFoundException("Пользователя с таким Id не существует.");

            return user;
        }


        public Users GetByEmail(string email)
        {
            Users user = _userRepository.GetByEmail(email);

            if (user == null)
                throw new NotFoundException("Пользователя с таким email не существует.");

            return user;
        }


        public Users Create(Users user)
        {
            Users existUser = _userRepository.GetByEmail(user.Email);

            if (existUser != null)
                throw new AlreadyExistsException("Пользователь с таким Email уже существует.");

            return _userRepository.Create(user);
        }


        public Users Update(Users user)
        {
            return _userRepository.Update(user);
        }


        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
        }
    }
}
