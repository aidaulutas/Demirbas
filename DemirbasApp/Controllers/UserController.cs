using DemirbasData.DataContext;
using DemirbasData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemirbasApp.Controllers
{
    public class UserController : Controller
    {
        private readonly DemirbasContext _context;

        public UserController(DemirbasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Users.Include(x=>x.Department).Where(x=> !x.IsDeleted).ToList();
            return View(model);
        }
        [HttpGet] 
        public IActionResult Create()
        {
            ViewBag.Department = _context.Departments.Where(x=> !x.IsDeleted).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(User UserModel)
        {
            _context.Users.Add(UserModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update (int id) 
        {
            var user = _context.Users.Find(id);
            ViewBag.Department = _context.Departments.Where( x=> !x.IsDeleted).ToList();
            return View(user);
        }
        [HttpPost]
        public IActionResult Update(User UserModel) 
        {
            _context.Users.Update(UserModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id).IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
