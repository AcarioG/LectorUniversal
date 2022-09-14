using AutoMapper;
using LectorUniversal.Server.Data;
using LectorUniversal.Server.Helpers;
using LectorUniversal.Server.Models;
using LectorUniversal.Shared;
using LectorUniversal.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LectorUniversal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileUpload _fileUpload;
        private readonly UserManager<ApplicationUser> _userManager;
        public ChaptersController(ApplicationDbContext db, IMapper mapper, IFileUpload fileUpload, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _mapper = mapper;
            _fileUpload = fileUpload;
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var chapters = await _db.Chapters.ToListAsync();
            return Ok(chapters);
        }

        [HttpGet("viewer/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<VisualiseBookDTO>> Get(int id, int bookid)
        {
            List<Chapter> chapter = new List<Chapter>();

            chapter.Add(await _db.Chapters.Where(x => x.Id == id)
            .Include(b => b.Books)
            .Include(p => p.ChapterPages.Where(x => x.Chapter.Id == id))
            .FirstOrDefaultAsync());

            if (chapter == null)
            {
                return NotFound();
            }

            var model = new VisualiseBookDTO();

            model.Chapters = chapter;
            model.Book = chapter.Select(x => x.Books).FirstOrDefault();
            model.Pages = chapter.Select(x => x.ChapterPages).First().ToList();

            return model;
        }

        [HttpPost("mark")]
        public async Task<IActionResult> MarkChapter(ChapterFinished mark)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var userId = user.Id;

            var markActual = await _db.ChapterFinisheds
                .FirstOrDefaultAsync(x => x.ChapterId == mark.ChapterId && x.UserId == userId);

            if (markActual == null)
            {
                mark.UserId = userId;
                _db.Add(mark);
                await _db.SaveChangesAsync();
            }
            else
            {
                markActual.Finished = mark.Finished;
                await _db.SaveChangesAsync();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Chapter chapter)
        {
            await _db.AddAsync(chapter);
            await _db.SaveChangesAsync();
            return chapter.Id;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exits = await _db.Chapters.AsNoTracking().AnyAsync(x => x.Id == id);
            if (!exits) { return NotFound(); }

            var chapter = await _db.Chapters.AsNoTracking().Where(x => x.Id == id)
                .Include(x => x.Books).Where(x => x.BooksId == x.Books.Id).FirstOrDefaultAsync();

            var pages = await _db.Pages.Where(x => x.ChapterId == id).FirstOrDefaultAsync();

            var folder = $"{chapter.Books.Name.Replace(" ", "-").Replace(":", "").Replace("#", "")}/{chapter.Title.Replace(" ", "-").Replace(":", "").Replace("#", "")}";
            var bookType = Enum.GetName(chapter.Books.TypeofBook);
            bool complete = true;
            await _fileUpload.DeleteChapter(folder, bookType, pages.ImageUrl, complete);

            _db.Remove(new Chapter{ Id = id });
            await _db.SaveChangesAsync();
            return NoContent();
        }

    }
}
