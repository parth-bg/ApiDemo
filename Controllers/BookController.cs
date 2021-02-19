using ApiDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _bookRepository.GetAllBooks();
            return Ok(model);
        }

        [HttpGet("{BookId}")]
        public IActionResult Details(int BookId)
        {
            Book book = _bookRepository.GetBook(BookId);
            if (book == null)
            {
                return NotFound("The Book record couldn't be found");
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book cannot be created.");
            }
            _bookRepository.Add(book);
            return CreatedAtAction(nameof(Details), new { Id = book.BookId }, book);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book model)
        {
            Book book = _bookRepository.GetBook(model.BookId);
            if (book == null)
            {
                return NotFound($"Book with BookId = {model.BookId} cannot be found");
            }
            book.Title = model.Title;
            book.Price = model.Price;
            _bookRepository.Update(book);
            return Ok();
        }

        [HttpDelete("{BookId}")]
        public IActionResult Delete(int BookId)
        {
            Book book = _bookRepository.Delete(BookId);
            if (book == null)
            {
                return NotFound($"Book with BookId = {BookId} cannot be found");
            }
            return Ok(book);            
        }
    }
}