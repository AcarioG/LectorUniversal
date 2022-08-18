using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorUniversal.Shared.DTOs
{
    public class BookUpdateDTO
    {
        public Book Book { get; set; }
        public List<Editorial> Editorials { get; set; }
        public List<Gender> GendersSelected { get; set; }
        public List<Gender> GendersNotSelected { get; set; }
    }
}
