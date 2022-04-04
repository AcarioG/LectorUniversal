

namespace LectorUniversal.Shared.DTOs
{
    public class VisualiseBookDTO
    {
        public Book Book { get; set; }
        public List<Chapter>? Chapters { get; set; }
        public List<Gender>? Genders { get; set; }
    }
}
