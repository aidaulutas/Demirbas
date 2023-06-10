using DemirbasData.DataContext;
using Microsoft.AspNetCore.Mvc;
using DemirbasData.Model;

namespace DemirbasApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DemirbasContext _context;

        public DepartmentController(DemirbasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Departments.Where(x => !x.IsDeleted).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department DepartmentModel)
        {
            _context.Departments.Add(DepartmentModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var department = _context.Departments.Find(id);
            return View(department);
        }
        [HttpPost]
        public IActionResult Update(Department DepartmentModel)
        {
            _context.Departments.Update(DepartmentModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id).IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
