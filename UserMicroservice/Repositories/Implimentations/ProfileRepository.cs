using UserMicroservice.Database;
using UserMicroservice.Models.Database;
using UserMicroservice.Repositories.Interfaces;

namespace UserMicroservice.Repositories.Implimentations
{
    public class ProfileRepository : BaseRepository<Profiles>, IProfileRepository
    {
        public ProfileRepository(AppDbContext Context) : base(Context) { }

        public Profiles GetByUserId(Guid userId)
        {
            return Context.Profiles.FirstOrDefault(p => p.UserId == userId);
        }
    }
}
