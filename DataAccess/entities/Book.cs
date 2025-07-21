#nullable disable

using DataAccess.Enums;
using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;


namespace DataAccess.entities
{
    public class Book:RecordBase
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public string Author { get; set; }
        
        public Genre Genre { get; set; }
        public DateTime publishDate {  get; set; }
        public bool isPublished { get; set; }

        public int TypesId { get; set; }//foreign key
        public Types Types { get; set; }
        public List<BookOwner> BookOwners { get; set; }

    }
}
