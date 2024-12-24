using UserMicroservice.Models.Database;

namespace UserMicroservice.Services.Interfaces
{
    public interface IUserService
    {
        public ICollection<Users> GetAll();
        public Users GetById(Guid id);
        public Users GetByEmail(string email);
        public Users Create(Users user);
        public Users Update(Users user);
        public void Delete(Guid user);
    }
}
