#nullable disable
using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;


namespace DataAccess.entities
{
    public class Owner:RecordBase
    {
        [Required]
        [StringLength(50)]
        public string Name {  get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool isActive { get; set; } //whether owner actively can use the system
        public decimal Score { get; set; } //between 0 and 5
        public List<BookOwner> BookOwners { get; set; }




    }
}
