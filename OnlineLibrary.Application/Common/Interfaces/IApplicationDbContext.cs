using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Client> Clients { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
