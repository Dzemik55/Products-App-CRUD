using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class UserController : Controller
    {
        private readonly DB_Context _db;

        public UserController(DB_Context db)
        {
            _db = db;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            IEnumerable<User> UserList = _db.Users;
            return View(UserList);
        }


        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_db.Roles, "Id", "Name");

            return View();
        }


        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,Pseudonim, Password, Email, RoleId")] User obj)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _db.Users.Add(obj);
                    _db.SaveChanges();
                    TempData["success"] = "User added successfully!";


                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    // Obsługa wyjątku spowodowanego przez naruszenie indeksu unique.
                    if (ex.InnerException is SqlException sqlException && sqlException.Number == 2601)
                    {
                        TempData["error"] = "User already exists!";
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["RoleId"] = new SelectList(_db.Roles, "Id", "Name", obj.RoleId);

            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDatabase = _db.Users.Find(id);

            if (userFromDatabase == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_db.Roles, "Id", "Name", userFromDatabase.RoleId);
            return View(userFromDatabase);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User obj)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    _db.Users.Update(obj);

                    _db.SaveChanges();
                    TempData["success"] = "User edited successfully!";


                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    // Obsługa wyjątku spowodowanego przez naruszenie indeksu unique.
                    if (ex.InnerException is SqlException sqlException && sqlException.Number == 2601)
                    {
                        TempData["error"] = "User already exists!";
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["RoleId"] = new SelectList(_db.Roles, "Id", "Name", obj.RoleId);
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDatabase = _db.Users.Find(id);

            if (userFromDatabase == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_db.Roles, "Id", "Name", userFromDatabase.RoleId);
            return View(userFromDatabase);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            var UserName = obj.Pseudonim;
            _db.Users.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "User  " + UserName.ToString() + " deleted successfully!";
            return RedirectToAction("Index");

        }
    }
}
