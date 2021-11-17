namespace LectorUniversal.Shared
{
    public partial class BooksGender 
    {
        public int? BookId { get; set; }
        public int? GenderId { get; set; }
        public virtual Book? Book { get; set; }
        public virtual Gender? Gender { get; set; }
    }
}
