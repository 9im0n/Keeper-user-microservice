using UserMicroservice.Models.Database;

namespace UserMicroservice.Repositories.Interfaces
{
    public interface IRefreshTokensRepository : IBaseRepository<RefreshTokens>
    {
        public RefreshTokens GetByToken(Guid token);
        public RefreshTokens GetByUserId(Guid userId);
    }
}
