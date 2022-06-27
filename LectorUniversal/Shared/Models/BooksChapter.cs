using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorUniversal.Shared
{
    public partial class BooksChapter
    {
        public int BookId { get; set; }
        public int ChapterId { get; set; }
        public virtual Book? Book { get; set; }
        public virtual Chapter? Chapter { get; set; }
    }
}
