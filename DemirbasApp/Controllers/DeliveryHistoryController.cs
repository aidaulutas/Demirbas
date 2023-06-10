using DemirbasData.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemirbasApp.Controllers
{
    public class DeliveryHistoryController : Controller
    {
        private readonly DemirbasContext _context;

        public DeliveryHistoryController(DemirbasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.DeliveryHistories.Include(x=> x.User).Include(x=> x.Item).Include(x=> x.Department).Where(x=> !x.IsDeleted).ToList();
            return View(model);
        }
       
    }
}
