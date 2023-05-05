using OnlineBookstore.Models;

namespace OnlineBookstore.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookById(int id);
        Task CreateBook(Book book);
        Task UpdateBook(int id, Book book);
        Task DeleteBook(int id);
    }
}
