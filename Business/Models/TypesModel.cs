#nullable disable

using DataAccess.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class TypesModel:RecordBase
    {
        #region Entity Properties
        [Required(ErrorMessage="{0} is required!")]
        [StringLength(50)]
        [DisplayName("Types Name")]
        public string Name { get; set; }
        #endregion

        #region Extra Properties
        [DisplayName("Book Count")]
       

        public int BookCount { get; set; }
        [DisplayName("Book Names")]
        public string BookNamesOutput { get; set; }
        #endregion

    }
}
