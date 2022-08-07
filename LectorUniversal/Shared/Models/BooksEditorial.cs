using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LectorUniversal.Shared
{
    public class BooksEditorial
    {
        public int? BookId { get; set; }
        public int? EditorialId { get; set; }
        [JsonIgnore]
        public Book? Book { get; set; }
        [JsonIgnore]
        public Editorial? Editorial { get; set; }
    }
}
