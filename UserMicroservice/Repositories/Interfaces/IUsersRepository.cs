using UserMicroservice.Models.Database;

namespace UserMicroservice.Repositories.Interfaces
{
    public interface IUsersRepository : IBaseRepository<Users>
    {
        public Users GetByEmail(string email);
    }
}
