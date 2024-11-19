using Microsoft.AspNetCore.Mvc;

namespace Arvefordeleren_WebAPI.Controllers
{
    public class TestatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
