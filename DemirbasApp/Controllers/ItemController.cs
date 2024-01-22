using DemirbasData.DataContext;
using DemirbasData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemirbasApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly DemirbasContext _context;

        public ItemController(DemirbasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Items.Include(x => x.Employee).Include(x => x.ItemType).Where(x => !x.IsDeleted).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ItemTypes = _context.ItemTypes.Where(x => !x.IsDeleted).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Item ItemModel)
        {

            _context.Items.Add(ItemModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.ItemTypes = _context.ItemTypes.Where(x => !x.IsDeleted).ToList();
            var item = _context.Items.Find(id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Update(Item ItemModel)
        {
            _context.Items.Update(ItemModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _context.Items.Find(id).IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UnassignedItemList()
        {
            var item = _context.Items.Include(x => x.ItemType).Include(x => x.Employee).Where(x => x.EmployeeId == null).ToList();
            return View(item);
        }
        [HttpGet]
        public IActionResult AssignedItemList()
        {
            var item = _context.Items.Include(x => x.ItemType).Include(x=> x.Employee).Where(x => x.EmployeeId != null).ToList();
            _context.SaveChanges();
            return View(item);
        }
        [HttpGet]
        public IActionResult AssignItem(int id)
        {
            var employee = _context.Employees.Where(x => !x.IsDeleted).ToList();
            ViewBag.ItemId = id;
            return View(employee);
        }
        [HttpGet]
        public IActionResult Assign(int Employeeid, int itemId)
        {
            var findItem = _context.Items.FirstOrDefault(x => x.Id == itemId).EmployeeId = Employeeid;
            var deliverHistory = new DeliveryHistory()
            {
                DeliveryDate = DateTime.Now,
                ItemId = itemId,
                EmployeeId = Employeeid,
                DepartmentId = _context.Employees.Find(Employeeid).DepartmentId
            };
            _context.DeliveryHistories.Add(deliverHistory);
            _context.SaveChanges();
            return RedirectToAction("UnassignedItemList");

        }
        [HttpGet]
        public IActionResult Unassign(int Employeeid, int itemId)
        {
            
            var item = _context.Items.Find(itemId).EmployeeId = null;
            var deliverHistory = _context.DeliveryHistories.FirstOrDefault(x => x.Id == itemId && x.EmployeeId == Employeeid).ReturnDate= DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}
