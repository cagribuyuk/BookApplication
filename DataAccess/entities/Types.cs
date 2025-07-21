#nullable disable
using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;


namespace DataAccess.entities
{
   public class Types:RecordBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public List<Book> Books { get; set; }

    }
}
