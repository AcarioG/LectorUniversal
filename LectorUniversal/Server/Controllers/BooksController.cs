using LectorUniversal.Server.Service;
using LectorUniversal.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LectorUniversal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices _bookServices;

        public BooksController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        //GET: api/Books
        [HttpGet]
        public async Task<IEnumerable<Book>> GetAsync()
        {
            var comics = await _bookServices.GetAllBooksAsync();
            if (comics == null)
            {
                return (IEnumerable<Book>)NotFound();
            }

            return comics;
        }


        //POST: api/books
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Book book)
        {
            await _bookServices.AddBooksAsync(book);
            await _bookServices.SaveBooksAsync();

            return NoContent();
        }

        //DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Book book = await _bookServices.GetBookAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            await _bookServices.DeleteBooksAsync(book);
            await _bookServices.SaveBooksAsync();

            return NoContent();
        }

    }
}
