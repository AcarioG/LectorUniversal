using System.ComponentModel.DataAnnotations;

namespace LectorUniversal.Shared
{ 
    public partial class Chapter : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string? Synopsis { get; set; }
        public virtual Book? Books { get; set; }
        public virtual List<Page>? ChapterPages { get; set; }
    }
}
