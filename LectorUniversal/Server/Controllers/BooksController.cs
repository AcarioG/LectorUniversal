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
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileUpload _fileUpload;
        private readonly IMapper _mapper;

        public BooksController(ApplicationDbContext db, IFileUpload fileUpload,
            IMapper mapper)
        {
            _db = db;
            _fileUpload = fileUpload;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<VisualiseBookDTO>> Get(int id)
        {
            var Book = await _db.Books.Where(x => x.Id == id)
                .Include(x => x.Genders).ThenInclude(x => x.Gender)
                .Include(x => x.Chapters.Where(c => c.BooksId == id))
                .FirstOrDefaultAsync();

            //var Chapter = await _db.Chapters.FirstOrDefaultAsync(;
            if (Book == null)
            {
                return NotFound();
            }

            var model = new VisualiseBookDTO();
            model.Book = Book;
            model.Genders = Book.Genders.Select(x => x.Gender).ToList();
            model.Chapters = Book.Chapters.ToList();

            return model;
        }

        
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Book>>> GetAll([FromQuery]PaginationDTO pagination)
        {
            var queryable = _db.Books.AsQueryable();
            await HttpContext.InsertParameterInResponse(queryable, pagination.Records);
            return await queryable.Pagination(pagination).ToListAsync();
        }

        [HttpGet("update/{id}")]
        public async Task<ActionResult<BookUpdateDTO>> PutGet(int id)
        {
            var bookActionResult = await Get(id);
            if (bookActionResult.Result is NotFoundResult) { return NotFound(); }

            var bookViewDTO = bookActionResult.Value;
            var gendersSelectedId = bookViewDTO.Genders.Select(x => x.Id).ToList();
            var genedersNotSelected = await _db.Genders.Where(x => !gendersSelectedId.Contains(x.Id)).ToListAsync();

            var model = new BookUpdateDTO();
            model.Book = bookViewDTO.Book;
            model.GendersNotSelected = genedersNotSelected;
            model.GendersSelected = bookViewDTO.Genders;
            return model;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Book book)
        {
            if (!string.IsNullOrWhiteSpace(book.Cover))
            {
                string folder = $"{book.Name.Replace(" ", "-")}";
                var coverPoster = Convert.FromBase64String(book.Cover);
                var bookType = Enum.GetName(book.TypeofBook);
                book.Cover = await _fileUpload.SaveFile(coverPoster, "jpg",bookType, folder);
            }

            _db.Add(book);
            await _db.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Book book)
        {
            var bookDB = await _db.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == book.Id);

            if (bookDB == null) { return NotFound(); }

            if (!string.IsNullOrWhiteSpace(book.Cover))
            {
                var coverImage = Convert.FromBase64String(book.Cover);
                var actualfolder = $"{bookDB.Name.Replace(" ", "-")}";
                var newfolder = $"{book.Name.Replace(" ", "-")}";
                var bookType = Enum.GetName(bookDB.TypeofBook);
                bool complete = false;
                bookDB.Cover = await _fileUpload.EditFile(coverImage, "jpg", actualfolder, newfolder, bookDB.Cover, bookType, complete);
            }

            bookDB = _mapper.Map(book, bookDB);
            
            await _db.Database.ExecuteSqlInterpolatedAsync($"delete from GenderBooks WHERE BookId = {book.Id};");

            bookDB.Genders = book.Genders;

            _db.Attach(bookDB).State = EntityState.Modified;
            await _db.GenderBooks.AddRangeAsync(bookDB.Genders);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exits = await _db.Books.AsNoTracking().AnyAsync(x => x.Id == id);
            if (!exits) { return NotFound(); }

            var book = await _db.Books.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            var folder = book.Name.Replace(" ", "-");
            var bookType = Enum.GetName(book.TypeofBook);
            bool complete = true;
            await _fileUpload.DeleteFile(folder,bookType, book.Cover, complete);

            _db.Remove(new Book { Id = id });
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
