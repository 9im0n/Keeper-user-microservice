using Microsoft.EntityFrameworkCore;
using UserMicroservice.Models.Database;

namespace UserMicroservice.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<RefreshTokens> RefreshTokens { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
