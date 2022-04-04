using AutoMapper;
using Azure.Storage.Blobs;
using LectorUniversal.Server.Data;
using LectorUniversal.Server.Helpers;
using LectorUniversal.Shared;
using LectorUniversal.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LectorUniversal.Server.Controllers
{
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
        public async Task<ActionResult<VisualiseBookDTO>> Get(int id)
        {
            var Book = await _db.Books.Where(x => x.Id == id).
                Include(x => x.Genders).ThenInclude(x => x.Gender).FirstOrDefaultAsync();

            if (Book == null)
            {
                return NotFound();
            }

            var model = new VisualiseBookDTO();
            model.Book = Book;
            //model.Genders = Book.Genders.Select(x => x.Gender).ToList();

            return model;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            var books = await _db.Books.ToListAsync();
            var booksDTO = _mapper.Map<List<BooksDTO>>(books);
            return Ok(booksDTO);
        }
       
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody]Book book )
        {
            if (!string.IsNullOrWhiteSpace(book.Cover))
            {
                var coverPoster = Convert.FromBase64String(book.Cover);
                string folder = book.Name.ToLower().Trim();
                book.Cover = _fileUpload.SaveFile(coverPoster, "jpg", folder).ToString();
            }
            _db.Add(book);
            await _db.SaveChangesAsync();
            return Ok(book);
        }
    }
}
