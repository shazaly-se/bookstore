using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBookAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            
            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] BookModel bookModel)
        {
            var id = await _bookRepository.AddBook(bookModel);
            return CreatedAtAction(nameof(GetBookById),  new { id = id, controller = "Books" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookModel,[FromRoute]int id)
        {
             await _bookRepository.UpdateBook(id,bookModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeleteBook(id);
            return Ok();
        }
    }
}
