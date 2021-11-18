using LectorUniversal.Server.Data;
using LectorUniversal.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        //[HttpGet]
        //public async Task<IActionResult> Get();
        //{
            
        //}

        [HttpPost]
        public async Task<ActionResult<int>> Post(Gender gender)
        {
            _db.Add(gender);
            await _db.SaveChangesAsync();
            return gender.Id;
        }
    }
}
