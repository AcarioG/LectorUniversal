using System.ComponentModel.DataAnnotations.Schema;

namespace LectorUniversal.Shared
{
    public class Page
    {
        public int Id { get; set; }
        public string? Image { get; set; }
    }
}