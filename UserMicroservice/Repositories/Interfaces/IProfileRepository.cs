using UserMicroservice.Models.Database;

namespace UserMicroservice.Repositories.Interfaces
{
    public interface IProfileRepository : IBaseRepository<Profiles>
    {
        public Profiles GetByUserId(Guid userId);
    }
}
