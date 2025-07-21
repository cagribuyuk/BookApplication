#nullable disable
using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;
using DataAccess.Enums;

namespace Business.Models
{
	public class BookModel:RecordBase
	{
		[Required]
		[StringLength(50)]
		public string Title { get; set; }
		public string Author { get; set; }

		public Genre Genre { get; set; }
		public DateTime publishDate { get; set; }
		public bool isPublished { get; set; }

		public int TypesId { get; set; }
	}
}
