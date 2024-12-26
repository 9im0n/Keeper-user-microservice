using Microsoft.EntityFrameworkCore;
using UserMicroservice.Database;
using UserMicroservice.Models.Database;
using UserMicroservice.Repositories.Interfaces;

namespace UserMicroservice.Repositories.Implimentations
{
    public class RefreshTokensRepository : BaseRepository<RefreshTokens>, IRefreshTokensRepository
    {
        public RefreshTokensRepository(AppDbContext context) : base(context) { }

        public RefreshTokens GetByToken(Guid token)
        {
            return Context.RefreshTokens.Include(t => t.User).FirstOrDefault(t => t.Token == token);
        }

        public RefreshTokens GetByUserId(Guid userId)
        {
            return Context.RefreshTokens.Include(t => t.User).FirstOrDefault(t => t.UserId == userId);
        }
    }
}
