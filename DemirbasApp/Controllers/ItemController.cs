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
            var model = _context.Items.Include(x => x.User).Include(x => x.ItemType).Where(x => !x.IsDeleted).ToList();
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
            var item = _context.Items.Include(x => x.ItemType).Where(x => x.UserId == null).ToList();
            return View (item);
        }
        [HttpGet]
        public IActionResult AssignItem(int id)
        {
            var user = _context.Users.Where(x => !x.IsDeleted).ToList();
            ViewBag.ItemId = id;
            return View (user);
        }
        [HttpGet]
        public IActionResult Assign(int Userid,int itemId)
        {
            var findItem = _context.Items.FirstOrDefault(x => x.Id == itemId).UserId = Userid;
            var deliverHistory = new DeliveryHistory()
            {
                DeliveryDate = DateTime.Now,
                ItemId = itemId,
                UserId = Userid,
                DepartmentId = _context.Users.Find(Userid).DepartmentId
            };
            _context.DeliveryHistories.Add(deliverHistory);
            _context.SaveChanges();
            return RedirectToAction("UnassignedItemList");

        }

    }
}
