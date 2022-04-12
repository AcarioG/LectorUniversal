using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LectorUniversal.Shared
{
    public class Gender : EntityBase 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<BooksGender>? GenderList { get; set; }
    }
}
