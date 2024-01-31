using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    public class StockTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
