using Microsoft.AspNetCore.Mvc;

namespace razorPages.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
