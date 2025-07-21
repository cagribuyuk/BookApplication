using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;

namespace Business.Services
{
	public interface IBookService
	{
		IQueryable<BookModel> Query();
	}
	public class BookService : ServiceBase, IBookService
	{
		public BookService(Db db) : base(db)
		{
		}

		public IQueryable<BookModel> Query()
		{
			return _db.Books.OrderBy(p => p.Title).Select(p => new BookModel()
			{
				Title = p.Title,
				Id = p.Id,
				Author = p.Author,
				Genre = p.Genre,
				publishDate = p.publishDate,
				isPublished = p.isPublished,
				TypesId = p.TypesId

			});
		}
	}
}
