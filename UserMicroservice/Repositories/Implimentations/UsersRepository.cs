using Microsoft.EntityFrameworkCore;
using UserMicroservice.Database;
using UserMicroservice.Models.Database;
using UserMicroservice.Repositories.Interfaces;

namespace UserMicroservice.Repositories.Implimentations
{
    public class UsersRepository : BaseRepository<Users>, IUsersRepository
    {
        public UsersRepository(AppDbContext Context) : base(Context) { }

        public override ICollection<Users> GetAll()
        {
            return Context.Users.Include(u => u.Profile).ToList();
        }

        public override Users GetById(Guid id)
        {
            return Context.Users.Include(u => u.Profile).FirstOrDefault(u => u.Id == id);
        }

        public Users GetByEmail(string email)
        {
            return Context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
