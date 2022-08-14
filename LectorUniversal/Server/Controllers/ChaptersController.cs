using AutoMapper;
using LectorUniversal.Server.Data;
using LectorUniversal.Server.Helpers;
using LectorUniversal.Shared;
using LectorUniversal.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
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
        public ChaptersController(ApplicationDbContext db, IMapper mapper, IFileUpload fileUpload)
        {
            _db = db;
            _mapper = mapper;
            _fileUpload = fileUpload;
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
        public async Task<ActionResult<VisualiseBookDTO>> Get(int id)
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
            //model.Genders = chapter.Select(x => x.Books.Genders.Select(x => x.Gender).ToList());

            return model;
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
