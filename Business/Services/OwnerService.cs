using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public interface IOwnerService
    {
        IQueryable<OwnerModel> Query();
        Result Add(OwnerModel model);
        Result Update(OwnerModel model);
        Result Delete(int id);
        List<OwnerModel> GetList();
        OwnerModel GetItem(int id);
    }
    public class OwnerService : ServiceBase, IOwnerService
    {
        public OwnerService(Db db) : base(db)
        {
        }

        public Result Add(OwnerModel model)
        {
			if (_db.Owners.Any(o => o.Name.ToLower() == model.Name.ToLower().Trim() && o.Surname.ToLower() == model.Surname.ToLower().Trim()))
				return new ErrorResult("Owner with same name and surname exists!");
			var entity = new Owner()
			{
				BirthDate = model.BirthDate,
				isActive = model.isActive,
				Name = model.Name.Trim(),
				Score = model.Score,
				Surname = model.Surname.Trim(),
				BookOwners = model.BookIdsInput?.Select(bookId => new BookOwner()
				{
					BookId = bookId
				}).ToList()
			};
			_db.Owners.Add(entity);
			_db.SaveChanges();
			model.Id = entity.Id;
			return new SuccessResult("Owner added successfuly.");
		}

        public Result Delete(int id)
		{
			var entity = _db.Owners.Include(o => o.BookOwners).SingleOrDefault(o => o.Id == id);
			if (entity is null)
				return new ErrorResult("Owner not found!");
			_db.BookOwners.RemoveRange(entity.BookOwners);
			_db.Owners.Remove(entity);
			_db.SaveChanges();
			return new SuccessResult("Owner deleted successfuly.");
		}

		public OwnerModel GetItem(int id) => Query().SingleOrDefault(o => o.Id == id);

        public List<OwnerModel> GetList() => Query().ToList();

        public IQueryable<OwnerModel> Query()
        {
            return _db.Owners.Include(o => o.BookOwners).ThenInclude(po => po.Book)
                 .OrderByDescending(o => o.isActive).ThenBy(o => o.BirthDate).ThenBy(o => o.Name).ThenBy(o => o.Surname)
                 .Select(o => new OwnerModel()
                 {
                     BirthDate = o.BirthDate,
                     Id = o.Id,
                     isActive = o.isActive,
                     Name = o.Name,
                     Score = o.Score,
                     Surname = o.Surname,

                     BirthDateOutput = o.BirthDate.HasValue ? o.BirthDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                     isActiveOutput = o.isActive ? "Active" : "Not Active",
                     ScoreOutput = o.Score.ToString("N1"),
                     FullNameOutput = o.Name + " " + o.Surname,

                     BookIdsInput = o.BookOwners.Select(po => po.BookId).ToList(), // for edit operation
                     BookNamesOutput = string.Join("<br />", o.BookOwners.Select(po => po.Book.Title))
                 });
        }

        public Result Update(OwnerModel model)
        {
			if (_db.Owners.Any(o => o.Id != model.Id && o.Name.ToLower() == model.Name.ToLower().Trim() && o.Surname.ToLower() == model.Surname.ToLower().Trim()))
				return new ErrorResult("Owner with same name and surname exists!");
			var entity = _db.Owners.Include(o => o.BookOwners).SingleOrDefault(o => o.Id == model.Id);
			if (entity is null)
				return new ErrorResult("Owner not found!");
			_db.BookOwners.RemoveRange(entity.BookOwners);
			entity.BirthDate = model.BirthDate;
			entity.isActive = model.isActive;
			entity.Name = model.Name.Trim();
            entity.Score = model.Score;
			entity.Surname = model.Surname.Trim();
			entity.BookOwners = model.BookIdsInput?.Select(bookId => new BookOwner()
			{
				BookId = bookId
			}).ToList();
			_db.Owners.Update(entity);
			_db.SaveChanges();
			return new SuccessResult("Owner updated successfuly.");
		}

	}
}

