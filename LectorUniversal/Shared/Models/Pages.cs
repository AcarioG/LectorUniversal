using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LectorUniversal.Shared
{
    public class Pages
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public int? ChapterId { get; set; }
        [JsonIgnore]
        public virtual Chapter? Chapter { get; set; }
    }
}
