using DemirbasData.DataContext;
using DemirbasData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemirbasApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DemirbasContext _context;

        public EmployeeController(DemirbasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Employees.Include(x=>x.Department).Where(x=> !x.IsDeleted).ToList();
            return View(model);
        }
        [HttpGet] 
        public IActionResult Create()
        {
            ViewBag.Department = _context.Departments.Where(x=> !x.IsDeleted).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee EmployeeModel)
        {
            _context.Employees.Add(EmployeeModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update (int id) 
        {
            var employee = _context.Employees.Find(id);
            ViewBag.Department = _context.Departments.Where( x=> !x.IsDeleted).ToList();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee EmployeeModel) 
        {
            _context.Employees.Update(EmployeeModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id).IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
