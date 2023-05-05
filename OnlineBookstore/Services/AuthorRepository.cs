using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Database.Context;
using OnlineBookstore.Interfaces;
using OnlineBookstore.Models;

namespace OnlineBookstore.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly OnlineBookstoreContext _context;
        public AuthorRepository(OnlineBookstoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }
        public async Task<Author> GetAuthorById(int id)
        {
            return await _context.Authors.FindAsync(id);
        }
        public async Task CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAuthor(int id, Author author)
        {
            var oldAuthor=await _context.Authors.FindAsync(id);
            if (oldAuthor != null)
            {
                oldAuthor.LastName = author.LastName;
                oldAuthor.FirstName = author.FirstName;
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }       
    }
}
