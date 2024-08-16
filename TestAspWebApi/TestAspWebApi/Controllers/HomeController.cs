using Microsoft.AspNetCore.Mvc;

namespace TestAspWebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
