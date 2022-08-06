using LectorUniversal.Server.Data;
using LectorUniversal.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LectorUniversal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EditorialsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Editorial>>> Get()
        {
            return await _db.Editorials.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Editorial>> Get(int id)
        {
            return await _db.Editorials.FirstOrDefaultAsync(e => e.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Editorial editorial)
        {
            _db.Add(editorial);
            await _db.SaveChangesAsync();
            return editorial.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Editorial editorial)
        {
            _db.Attach(editorial).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var exits = await _db.Editorials.AnyAsync(x => x.Id == id);
            if (!exits) { return NotFound(); }
            _db.Remove(new Editorial { Id = id });
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
