using Microsoft.AspNetCore.Mvc;

namespace Arvefordeleren_WebAPI.Controllers
{
    public class HeirController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
