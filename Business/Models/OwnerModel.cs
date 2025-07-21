#nullable disable
using DataAccess.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class OwnerModel:RecordBase
    {
        #region Entity Properties

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool isActive { get; set; } //whether owner actively can use the system
        public decimal Score { get; set; } //between 0 and 5
        #endregion
        #region Extra Properties
        [DisplayName("Books")]
        public List<int> BookIdsInput{ get; set; }

        [DisplayName("Birth Date")]
        public string BirthDateOutput { get; set; } 

        [DisplayName("Active")]
        public string isActiveOutput { get; set; } // "Active" or "Not Active"

        [DisplayName("Score")]
        public string ScoreOutput { get; set; } 

        [DisplayName("Full Name")]
        public string FullNameOutput { get; set; } 

        [DisplayName("Books")]
        public string BookNamesOutput { get; set; }
        #endregion
    }

}

