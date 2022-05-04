using System.Text.Json.Serialization;

namespace LectorUniversal.Shared.DTOs
{
    public class PageDTO
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
    }
}