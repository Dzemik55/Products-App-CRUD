using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class ProductController : Controller
    {
        private readonly DB_Context _db;

        public ProductController(DB_Context db)
        {
            _db = db;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            IEnumerable<Product> ProductList = _db.Products;
            return View(ProductList);
        }


        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewData["SubcategoryId"] = new SelectList(_db.Subcategories, "Id", "Name");
            ViewData["UserId"] = new SelectList(_db.Users, "Id", "Pseudonim");

            return View();
        }


        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,SubcategoryId, UserId, Description")] Product obj)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _db.Products.Add(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Product added successfully!";


                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    // Obsługa wyjątku spowodowanego przez naruszenie indeksu unique.
                    if (ex.InnerException is SqlException sqlException && sqlException.Number == 2601)
                    {
                        TempData["error"] = "Product already exists!";
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["SubcategoryId"] = new SelectList(_db.Subcategories, "Id", "Name", obj.SubcategoryId);
            ViewData["UserId"] = new SelectList(_db.Users, "Id", "Pseudonim", obj.UserId);
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDatabase = _db.Products.Find(id);

            if (productFromDatabase == null)
            {
                return NotFound();
            }
            return View(productFromDatabase);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    _db.Products.Update(obj);

                    _db.SaveChanges();
                    TempData["success"] = "Product edited successfully!";


                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    // Obsługa wyjątku spowodowanego przez naruszenie indeksu unique.
                    if (ex.InnerException is SqlException sqlException && sqlException.Number == 2601)
                    {
                        TempData["error"] = "Product already exists!";
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["SubcategoryId"] = new SelectList(_db.Subcategories, "Id", "Name", obj.SubcategoryId);
            ViewData["UserId"] = new SelectList(_db.Users, "Id", "Pseudonim", obj.UserId);
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDatabase = _db.Products.Find(id);

            if (productFromDatabase == null)
            {
                return NotFound();
            }
            return View(productFromDatabase);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Products.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            var ProductName = obj.Name;
            _db.Products.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Product " + ProductName.ToString() + " deleted successfully!";
            return RedirectToAction("Index");

        }
    }
}
