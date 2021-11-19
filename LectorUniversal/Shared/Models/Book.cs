namespace LectorUniversal.Shared
{
    public partial class Book : EntityBase
    {

        public int Id { get; set; }
        public BoBookTypes TypeofBook { get; set; }
        public string Name { get; set; }
        public string? Cover { get; set; }
        public string? Editorial { get; set; }
        public virtual List<Chapter>? Chapters { get; set; }
        public List<BooksGender> Genders { get; set; } = new List<BooksGender>();
    }

    public enum BoBookTypes
    {
        bobt_comic = 0,
        bobt_manga = 1
    }
}
