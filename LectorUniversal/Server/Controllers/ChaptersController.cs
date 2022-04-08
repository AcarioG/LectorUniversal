using AutoMapper;
using Azure.Storage.Blobs;
using LectorUniversal.Server.Data;
using LectorUniversal.Shared;
using LectorUniversal.Shared.DTOs;
using Microsoft.AspNetCore.Http;
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
        public ChaptersController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chapters = await _db.Chapters.ToListAsync();
            var chapterDTO = _mapper.Map<ChapterDTO>(chapters);
            return Ok(chapterDTO);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Chapter chapter)
        {
            await _db.AddAsync(chapter);
            await _db.SaveChangesAsync();
            return Ok(chapter);
        }

    }
}
