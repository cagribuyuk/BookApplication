#nullable disable
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class OwnersController : Controller
    {
        // TODO: Add service injections here
        private readonly IOwnerService _ownerService;
		private readonly IBookService _bookService;
		public OwnersController(IOwnerService ownerService, IBookService bookService)
		{
			_ownerService = ownerService;
			_bookService = bookService;
		}

		// GET: Owners
		public IActionResult Index()
        {
            List<OwnerModel> ownerList = _ownerService.GetList(); // TODO: Add get collection service logic here
            return View(ownerList);
        }

        // GET: Owners/Details/5
        public IActionResult Details(int id)
        {
            OwnerModel owner = _ownerService.GetItem(id); // TODO: Add get item service logic here
            if (owner == null)
            {
                //return NotFound();
                return View("Error", "Owner not found!");
            }
            return View(owner);
        }

        // GET: Owners/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewBag.Books = new MultiSelectList(_bookService.Query().ToList(), "Id", "Title");
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OwnerModel owner)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                var result = _ownerService.Add(owner);
                if (result.IsSuccessfull)
                {
                    TempData["Message"]= result.Message;
					return RedirectToAction(nameof(Index));

				}
                ModelState.AddModelError("", result.Message);
			}
			// TODO: Add get related items service logic here to set ViewData if necessary
			ViewBag.Books = new MultiSelectList(_bookService.Query().ToList(), "Id", "Title");
			return View(owner);
        }

        // GET: Owners/Edit/5
        public IActionResult Edit(int id)
        {
            OwnerModel owner = _ownerService.GetItem(id); // TODO: Add get item service logic here
            if (owner == null)
            {
				return View("Error", "Owner not found!");
			}
			// TODO: Add get related items service logic here to set ViewData if necessary
			ViewBag.Books = new MultiSelectList(_bookService.Query().ToList(), "Id", "Title");
			return View(owner);
        }

        // POST: Owners/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OwnerModel owner)
		{
			if (ModelState.IsValid)
			{
				// TODO: Add update service logic here
				var result = _ownerService.Update(owner);
				if (result.IsSuccessfull)
				{
					TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Details), new { id = owner.Id });
				}
				ModelState.AddModelError("", result.Message);
			}
			// TODO: Add get related items service logic here to set ViewData if necessary
			ViewBag.Books = new MultiSelectList(_bookService.Query().ToList(), "Id", "Title");
			return View(owner);
		}

		// GET: Owners/Delete/5
		public IActionResult Delete(int id)
		{
			OwnerModel owner = _ownerService.GetItem(id); // TODO: Add get item service logic here
			if (owner == null)
			{
				return View("Error", "Owner not found!");
			}
			return View(owner);
		}

		// POST: Owners/Delete
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
		{
			// TODO: Add delete service logic here
			var result = _ownerService.Delete(id);
			TempData["Message"] = result.Message;
			return RedirectToAction(nameof(Index));
		}
	}
}
