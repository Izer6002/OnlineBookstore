using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Interfaces;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateBook([FromBody] Book book)
        {
            var newBook = _bookRepository.CreateBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.BookID }, newBook);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            var existingBook = _bookRepository.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            var updatedBook = _bookRepository.UpdateBook(id,book);
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBook(int id)
        {
            var existingBook = _bookRepository.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            _bookRepository.DeleteBook(id);
            return NoContent();
        }
    }
}
