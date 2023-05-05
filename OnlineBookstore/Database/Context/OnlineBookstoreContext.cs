using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Models;

namespace OnlineBookstore.Database.Context
{
    public class OnlineBookstoreContext: DbContext
    {
        public OnlineBookstoreContext(DbContextOptions<OnlineBookstoreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
