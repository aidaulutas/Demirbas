using DemirbasData.DataContext;
using DemirbasData.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemirbasApp.Controllers
{
    public class ItemTypeController : Controller
    {
        private readonly DemirbasContext _context;

        public ItemTypeController(DemirbasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.ItemTypes.Where(x=> !x.IsDeleted).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create (ItemType ItemTypeModel)
        {
            _context.ItemTypes.Add(ItemTypeModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id) 
        {
            var itemType = _context.ItemTypes.Find(id);
            return View (itemType);
        }
        [HttpPost]
        public IActionResult Update(ItemType ItemTypeModel)
        {
            _context.ItemTypes.Update(ItemTypeModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var itemType = _context.ItemTypes.Find(id).IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
