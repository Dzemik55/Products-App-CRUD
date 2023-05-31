using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class RoleController : Controller
    {
        private readonly DB_Context _db;

        public RoleController(DB_Context db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Role> objRoleList = _db.Roles;
            return View(objRoleList);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var roleFromDatabase = _db.Roles.Find(id);

            if (roleFromDatabase == null)
            {
                return NotFound();
            }
            return View(roleFromDatabase);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Role obj)
        {
            if (ModelState.IsValid)
            {
                _db.Roles.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Role edited successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Role obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Roles.Add(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Role created successfully!";
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    // Obsługa wyjątku spowodowanego przez naruszenie indeksu unique.
                    if (ex.InnerException is SqlException sqlException && sqlException.Number == 2601)
                    {
                        ModelState.AddModelError(string.Empty, "Role already exists!");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var roleFromDatabase = _db.Roles.Find(id);

            if (roleFromDatabase == null)
            {
                return NotFound();
            }
            return View(roleFromDatabase);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Roles.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Roles.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Role deleted successfully!";
            return RedirectToAction("Index");

        }
    }
}