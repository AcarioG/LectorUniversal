using System.ComponentModel.DataAnnotations.Schema;
namespace LectorUniversal.Shared
{
    public class Gender : EntityBase 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public List<BooksGender>? GenderList { get; set; }
    }
}
