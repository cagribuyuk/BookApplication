#nullable disable
using Business.Models;
using Business.Services;
using DataAccess.Results.Bases;
using Microsoft.AspNetCore.Mvc;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class TypesController : Controller
    {
        // TODO: Add service injections here
        private readonly ITypesService _typesService;

        public TypesController(ITypesService typesService)
        {
            _typesService = typesService;
        }

        // GET: Types
        public IActionResult Index()
        {
            List<TypesModel> typesList = _typesService.Query().ToList(); // TODO: Add get collection service logic here
            return View(typesList);
        }

        // GET: Types/Details/5
        public IActionResult Details(int id)
        {
            TypesModel types = _typesService.Query().SingleOrDefault(t=>t.Id==id); // TODO: Add get item service logic here
            if (types == null)
            {
                return NotFound();
            }
            return View(types);
        }

        // GET: Types/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View();
        }

        // POST: Types/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TypesModel types)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                Result result = _typesService.Add(types);
                if (result.IsSuccessfull)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
                return RedirectToAction(nameof(Index));
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(types);
        }

        // GET: Types/Edit/5
        public IActionResult Edit(int id)
        {
            TypesModel types = _typesService.Query().SingleOrDefault(t=>t.Id==id); // TODO: Add get item service logic here
            if (types == null)
            {
                return NotFound();
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(types);
        }

        // POST: Types/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TypesModel types)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                Result result= _typesService.Update(types);
                if(result.IsSuccessfull)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("",result.Message);
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(types);
        }

        // GET: Types/Delete/5
        public IActionResult Delete(int id)
        {
            TypesModel types = _typesService.Query().SingleOrDefault(t => t.Id == id); // TODO: Delete item service logic here
            if (types == null)
            {
                return NotFound();
            }
            return View(types);
        }

        // POST: Types/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            Result result = _typesService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
