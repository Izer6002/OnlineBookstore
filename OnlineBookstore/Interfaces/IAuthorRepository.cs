using OnlineBookstore.Models;

namespace OnlineBookstore.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthors();
        Task<Author> GetAuthorById(int id);
        Task CreateAuthor(Author author);
        Task UpdateAuthor(int id, Author author);
        Task DeleteAuthor(int id);
    }
}
