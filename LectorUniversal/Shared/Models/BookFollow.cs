using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorUniversal.Shared
{
    public class BookFollow
    {
        public Guid Id { get; set; }
        public string BookState { get; set; } = string.Empty;
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public string? UserId { get; set; }
    }

    public class ChapterFinished
    {
        public Guid Id { get; set; }
        public int Finished { get; set; }
        public int ChapterId { get; set; }
        public Chapter? Chapter { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
