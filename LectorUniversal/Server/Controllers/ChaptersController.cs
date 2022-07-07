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

    [Authorize(Roles = "admin")]
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
            //var chapterDTO = _mapper.Map<ChapterDTO>(chapters);
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
            var book = await _db.Books.Where(x => x.Id == chapter.BooksId).FirstOrDefaultAsync();
                    string folder = $"{book.Name.Replace(" ", "-")}/{chapter.Title.Replace(" ", "-")}";
            var bookType = Enum.GetName(book.TypeofBook);
            //Shared.Pages pages = new Shared.Pages();
            List<string> imgUrl = new List<string>();
            foreach (var item in chapter.ChapterPages)
            {
                var ChapterPage = Convert.FromBase64String(item.ImageUrl);
                 imgUrl.Add(await _fileUpload.SaveFile(ChapterPage, "jpg",bookType, folder));
            }
            chapter.ChapterPages.RemoveRange(0,chapter.ChapterPages.Count());
            foreach (var item in imgUrl)
            {
                chapter.ChapterPages.Add(new Shared.Pages { ImageUrl = item});
            }

            await _db.AddAsync(chapter);
            await _db.SaveChangesAsync();
            return Ok(chapter);
        }

    }
}
