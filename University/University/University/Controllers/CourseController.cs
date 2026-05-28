using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;
using University.ViewModel;
using University.ViewModel.CoursesVM;
using University.ViewModel.CourseVM;

namespace University.Controllers
{
    public class CourseController : Controller
    {
        private readonly UniversityContext _context;
        public CourseController(UniversityContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var result = _context.Courses
                .Select(r => new CourseIndexViewModel
                {
                    CourseId = r.CourseId,
                    Credits = r.Credits,
                    Title = r.Title,
                    DepartmentId = r.DepartmentId,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = r.Departments.Name
                    }
                });

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vm = await _context.Courses
                .Where(c => c.CourseId == id)
                .Select(c => new CourseUpdateViewModel
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Credits = c.Credits,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Departments.Name
                    }
                })
                .FirstOrDefaultAsync();
            //tuleb teha domaini modelist andmete ülekanne view modeli omasse
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CourseUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var updat = new Course
                {
                    CourseId = vm.CourseId,
                    Title = vm.Title,
                    Credits = vm.Credits,
                    Departments = new Department
                    {
                        Name = vm.Department.DepartmentName
                    }
                };

                _context.Update(updat);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
