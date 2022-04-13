using LectorUniversal.Server.Data;
using LectorUniversal.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LectorUniversal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public GendersController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Gender>>> Get()
        {
            return await _db.Genders.ToListAsync(); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gender>> Get(int id)
        {
            return await _db.Genders.FirstOrDefaultAsync(g => g.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Gender gender)
        {
            _db.Add(gender);
            await _db.SaveChangesAsync();
            return gender.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Gender gender)
        {
            _db.Attach(gender).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exits = await _db.Genders.AnyAsync(x => x.Id == id);
            if (!exits)  { return NotFound(); }
            _db.Remove(new Gender { Id = id });
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
