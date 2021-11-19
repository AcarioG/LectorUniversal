using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorUniversal.Shared.DTOs
{
    public class BooksDTO
    {
        public int Id { get; set; }
        public BoBookTypes TypeofBook { get; set; }
        public string Name { get; set; }
        public string? Cover { get; set; }
        public string? Editorial { get; set; }
        public virtual List<ChapterDTO>? Chapters { get; set; }
    }
}
