using System.ComponentModel.DataAnnotations;

namespace LectorUniversal.Shared
{
    public class Chapter : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string? Synopsis { get; set; }
        public Book? Books { get; set; }
        public List<Pages>? ChapterPages { get; set; } = new List<Pages>();
    }
}
