using LectorUniversal.Server.Data;
using LectorUniversal.Server.Models;
using LectorUniversal.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LectorUniversal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public FollowController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> PostFollow(BookFollow bookFollow)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var userId = user.Id;

            var followActual = _db.BookFollows.FirstOrDefault(f => f.BookId == bookFollow.BookId && f.UserId == userId);

            if (followActual == null)
            {
                bookFollow.UserId = userId;
                _db.Add(bookFollow);
                await _db.SaveChangesAsync();
            }
            else
            {
                followActual.BookState = bookFollow.BookState;
                await _db.SaveChangesAsync();
            }

            return NoContent();
        }
    }
}
