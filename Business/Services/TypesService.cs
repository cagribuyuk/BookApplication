

using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public interface ITypesService
    {
        IQueryable<TypesModel> Query();
        Result Add(TypesModel model);
        Result Update(TypesModel model);
        Result Delete(int id);
    }
    public class TypesService : ServiceBase, ITypesService
    {
        public TypesService(Db db) : base(db)
        {
        }

        public Result Add(TypesModel model)
        {
            if (_db.Types.Any(t => t.Name.ToLower() == model.Name.ToLower().Trim()))
                return new ErrorResult("Types with the same name exists!");
            Types entity = new Types()
            {
                Name = model.Name.Trim()
            };

            _db.Types.Add(entity);
            _db.SaveChanges();
            return new SuccessResult("Types added succesfully!");
        }

        public Result Delete(int id)
        {
            Types entity = _db.Types.Include(t=>t.Books).SingleOrDefault(t => t.Id == id);
            if (entity is null)
                return new ErrorResult("Types not found!");
            if (entity.Books is not null && entity.Books.Any())
                return new ErrorResult("Types cannot be deleted because it has a relation path!");
           
            _db.Types.Remove(entity);
            _db.SaveChanges();
            return new SuccessResult("Types deleted succesfully!");
        }

        public IQueryable<TypesModel> Query()
        {
            return _db.Types.Include(t => t.Books).OrderBy(t => t.Name).Select(t => new TypesModel()
            {
                Id = t.Id,
                Name = t.Name,

                BookCount = t.Books.Count,
                BookNamesOutput = string.Join("<br />", t.Books.OrderByDescending(t => t.publishDate).ThenBy(t => t.Title).Select(t => t.Title))

            });
        }

        public Result Update(TypesModel model)
        {
            if (_db.Types.Any(t => t.Id != model.Id && t.Name.ToLower()== model.Name.ToLower().Trim()))
                return new ErrorResult("Types with the same name exists!");
            Types entity = _db.Types.Find(model.Id);
           if (entity is null)
                return new ErrorResult("Types not found!");
           entity.Name=model.Name.Trim();   

            _db.Types.Update(entity);
            _db.SaveChanges();
            return new SuccessResult("Types updated succesfully!");
        }
    }
}
