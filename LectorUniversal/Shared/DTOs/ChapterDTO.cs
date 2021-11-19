using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorUniversal.Shared.DTOs
{
    public class ChapterDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string? Synopsis { get; set; }
        public virtual List<PageDTO>? ChapterPages { get; set; }
    }
}
