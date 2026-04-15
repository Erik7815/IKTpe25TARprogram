using Microsoft.AspNetCore.Mvc;
using University.Data;
using Microsoft.EntityFrameworkCore;

namespace University.Controllers
{
    public class StudentController : Controller
    {
        private readonly UniversityContext _context;
        public StudentController
            (UniversityContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Students.ToListAsync();

            return View(data);
        }
    }
}
