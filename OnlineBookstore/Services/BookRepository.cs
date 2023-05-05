using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Database.Context;
using OnlineBookstore.Interfaces;
using OnlineBookstore.Models;

namespace OnlineBookstore.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly OnlineBookstoreContext _context;
        public BookRepository(OnlineBookstoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book> GetBookById(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task CreateBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateBook(int id, Book book)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook != null)
            {
                existingBook.Genre = book.Genre;
                existingBook.Title = book.Title;
                existingBook.PublicationYear = book.PublicationYear;
                existingBook.Price = book.Price;
                existingBook.AuthorID = book.AuthorID;
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBook(int id)
        {
            var book = await _context.Authors.FindAsync(id);
            _context.Authors.Remove(book);
            await _context.SaveChangesAsync();
        }   
    }
}
