using LectorUniversal.Server.Data;
using LectorUniversal.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LectorUniversal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            return await _db.Books.ToListAsync();
        }
       
        [HttpPost]
        public async Task<ActionResult<int>> Post(Book book)
        {
            _db.Add(book);
            await _db.SaveChangesAsync();
            return Ok(book);
        }
    }
}
