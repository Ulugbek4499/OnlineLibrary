using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Entites;
using OnlineLibrary.Domain.Entites.Identity;

namespace OnlineLibrary.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRefreshToken> RefreshTokens { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
