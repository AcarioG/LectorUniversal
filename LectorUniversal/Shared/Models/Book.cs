namespace LectorUniversal.Shared
{
    public partial class Book : EntityBase
    {

        public int Id { get; set; }
        public BoBookTypes TypeofBook { get; set; }
        public string? Name { get; set; }
        public string? Cover { get; set; }
        public string? Synopsis { get; set; }
        public int? EditorialId { get; set; }
        public Editorial? Editorial { get; set; }
        public virtual List<Chapter>? Chapters { get; set; }
        public List<BooksGender>? Genders { get; set; } = new List<BooksGender>();
    }

    public enum BoBookTypes
    {
        Comic = 0,
        Manga = 1
    }
}
