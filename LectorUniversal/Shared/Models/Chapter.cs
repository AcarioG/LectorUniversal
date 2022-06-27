using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LectorUniversal.Shared
{
    public partial class Chapter : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Pages>? ChapterPages { get; set; } = new List<Pages>();
        public int? BooksId { get; set; }
        [JsonIgnore]
        public virtual Book? Books { get; set; }
    }
}
