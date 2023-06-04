using ApiBookList.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace ApiBookList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly AppLogger logger;

        public BooksController(AppDbContext context, AppLogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> ListAsync()
        {
            logger.LogInformation("Start listing books");
            var books = await context.Books.ToListAsync();
            logger.LogInformation($"Found {books.Count} books");
            return Ok(books);
        }

        [HttpPost("GetPostBook")]
        public async Task<ActionResult<Book>> GetPostBookAsync([FromBody] int bookId)
        {
            logger.LogInformation($"Serching BookId:{bookId} book");
            var book = await context.Books.SingleOrDefaultAsync(b => b.BookId == bookId);

            if (book == null)
            {
                return NotFound();
            }
            logger.LogInformation($"Show BookId:{bookId} book");
            return Ok(book);
        }
    }
}

