using Microsoft.AspNetCore.Mvc;
using Diplom.Data;
using Diplom.Models;

namespace Diplom.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid) 
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Success create";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id==null||id==0)
            {
                return NotFound();//404
            }
            var categoryFromDb=_db.Categories.Find(id);
            // var categoryFromFirst = _db.Categories.FirstOrDefault(c => c.Id==id);
            if (categoryFromDb==null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Edit Success";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();//404
            }
            var categoryFromDb = _db.Categories.Find(id);
            // var categoryFromFirst = _db.Categories.FirstOrDefault(c => c.Id==id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost (int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj== null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Success delete";
            return RedirectToAction("Index");
        }
    }
}
