using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class SubcategoryController : Controller
    {
        private readonly DB_Context _db;

        public SubcategoryController(DB_Context db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Subcategory> objCategoryList = _db.Subcategories;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var subcategoryFromDatabase = _db.Subcategories.Find(id);

            if (subcategoryFromDatabase == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_db.Categories, "Id", "Name", subcategoryFromDatabase.CategoryId);
            return View(subcategoryFromDatabase);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Subcategory obj)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    _db.Subcategories.Update(obj);
                    var category = _db.Categories.Find(obj.CategoryId);

                    _db.SaveChanges();
                    TempData["success"] = "Subcategory edited successfully!";


                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    // Obsługa wyjątku spowodowanego przez naruszenie indeksu unique.
                    if (ex.InnerException is SqlException sqlException && sqlException.Number == 2601)
                    {
                        TempData["error"] = "Subcategory already exists!";
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["CategoryId"] = new SelectList(_db.Categories, "Id", "Name", obj.CategoryId);
            return View(obj);
        }

        //GET
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_db.Categories, "Id", "Name");

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,CategoryId")] Subcategory obj)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _db.Subcategories.Add(obj);
                    var category = _db.Categories.Find(obj.CategoryId);
                    _db.SaveChanges();
                    TempData["success"] = "Subcategory created successfully!";


                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    // Obsługa wyjątku spowodowanego przez naruszenie indeksu unique.
                    if (ex.InnerException is SqlException sqlException && sqlException.Number == 2601)
                    {
                        TempData["error"] = "Subcategory already exists!";
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["CategoryId"] = new SelectList(_db.Categories, "Id", "Name", obj.CategoryId);
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var subcategoryFromDatabase = _db.Subcategories.Find(id);

            if (subcategoryFromDatabase == null)
            {
                return NotFound();
            }
            return View(subcategoryFromDatabase);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Subcategories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            var Subcategoryname = obj.Name;
            _db.Subcategories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Subcategory " + Subcategoryname.ToString() + " deleted successfully!";
            return RedirectToAction("Index");

        }
    }
}