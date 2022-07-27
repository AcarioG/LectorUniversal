using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorUniversal.Shared
{
    public class Votes
    {
        public int Id { get; set; }
        public int Vote { get; set; }
        public DateTime? VoteDate { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public string? UserId { get; set; }

    }
}
