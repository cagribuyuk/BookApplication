#nullable disable
using DataAccess.Records.Bases;

namespace DataAccess.entities
{
   public class BookOwner:RecordBase
    {
        public int BookId {  get; set; }
        public Book Book { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }


    }
}
