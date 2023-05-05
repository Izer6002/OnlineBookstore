using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Database.Context;
using OnlineBookstore.Interfaces;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors=_authorRepository.GetAuthors();
            return Ok(authors);
        }
        [HttpGet("{id}")]
        private IActionResult GetAuthorsById(int id)
        {
            var author=_authorRepository.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateAuthor([FromBody] Author author)
        {
            var newAuthor = _authorRepository.CreateAuthor(author);
            return CreatedAtAction(nameof(GetAuthorsById), new { id = author.AuthorID }, newAuthor);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateAuthor(int id, [FromBody] Author author)
        {
            var existingAuthor = _authorRepository.GetAuthorById(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }
            var updatedAuthor = _authorRepository.UpdateAuthor(id,author);
            return Ok(updatedAuthor);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAuthor(int id)
        {
            var existingAuthor = _authorRepository.GetAuthorById(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }
            _authorRepository.DeleteAuthor(id);
            return NoContent();
        }
    }
}
