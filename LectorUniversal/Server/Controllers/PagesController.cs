using LectorUniversal.Server.Data;
using LectorUniversal.Server.Helpers;
using Microsoft.AspNetCore.Mvc;


namespace LectorUniversal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileUpload _fileUpload;

        public PagesController(ApplicationDbContext db, IFileUpload fileUpload)
        {
            _db = db;
            _fileUpload = fileUpload;
        }

        // GET: api/<PagesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PagesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PagesController>
        [HttpPost]
        public async Task<ActionResult> Post(Shared.Pages Images)
        {
            var Chapter = _db.Chapters.Where(x => x.Id == Images.ChapterId).FirstOrDefault();
            var Book = _db.Books.Where(x => x.Id == Chapter.BooksId).FirstOrDefault();

            string folder = $"{Book.Name.Replace(" ", "-")}/{Chapter.Title.Replace(" ", "-")}";
            var bookType = Enum.GetName(Book.TypeofBook);

            var ChapterPage = Convert.FromBase64String(Images.ImageUrl);
            var Image = await _fileUpload.SaveFile(ChapterPage, "jpg", bookType, folder);

            Images.ImageUrl = Image;

            await _db.Pages.AddAsync(Images);
            await _db.SaveChangesAsync();

            return Ok(Images);
        }

        // PUT api/<PagesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PagesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
