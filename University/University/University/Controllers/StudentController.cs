using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
