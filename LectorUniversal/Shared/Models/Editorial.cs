using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LectorUniversal.Shared 
{ 
    public class Editorial
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<BooksEditorial>? BookEditorials { get; set; }
    }
}
