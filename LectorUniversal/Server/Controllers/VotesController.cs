using LectorUniversal.Server.Data;
using LectorUniversal.Server.Models;
using LectorUniversal.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LectorUniversal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public VotesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Votes vote)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var userId = user.Id;

            var votoActual = await _context.BookVotes
                .FirstOrDefaultAsync(x => x.BookId == vote.BookId && x.UserId == userId);

            if (votoActual == null)
            {
                vote.UserId = userId;
                vote.VoteDate = DateTime.Today;
                _context.Add(vote);
                await _context.SaveChangesAsync();
            }
            else
            {
                votoActual.Vote = vote.Vote;
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }
    }
}
