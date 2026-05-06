using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;
using University.Utilities;
using University.ViewModel;

namespace University.Controllers
{
    public class StudentController : Controller
    {
        private readonly UniversityContext _context;

        public StudentController
            (
                UniversityContext context
            )
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchstring, int? pageNumber, string currentFilter)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchstring;

            if (searchstring != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchstring = currentFilter;
            }

            //var students = from s in _context.Students select s;
            var students = _context.Students
                .Select(s => new ViewModel.StudentIndexViewModel
                {
                    Id = s.Id,
                    LastName = s.LastName,
                    FirstMidName = s.FirstMidName,
                    EnrollmentDate = s.EnrollmentDate
                    //miks kasutame ToListAsync()?
                    //kui me kasutame ToListAsync(), siis me saame tulemuse listina
                });
            if (string.IsNullOrEmpty(searchstring))
            {
                students = students.Where(s => s.LastName.Contains(searchstring)
                || s.FirstMidName.Contains(searchstring));
            }

            

            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;

                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;

                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;

                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
            var result = await students.ToListAsync();

            int pageSize = 3;

            return View(await PaginatedList<StudentIndexViewModel>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
            //leiame kõik student'id ja teisendame need StudentIndexViewModel'iks
            //miks peab kasutama await?
            //kui me kasutame await, siis me ootame kuni päring on lõpetatud
            //ja saame tulemuse, enne kui me jätkame koodi täitmist
            
        }

        public async Task<IActionResult> Details(int? id)
        {
            //kui id on null, siis tagastame NotFound() tulemuse
            if (id == null)
            {
                return NotFound();
            }

            //leiame student'i id järgi
            var student = await _context.Students
                //Include lubab objekti kasutada objekti sees
                .Include(s => s.Enrollments)
                    //kui tahad uuesti objekti kasutada objekti sees, siis kasutad ThenInclude
                    .ThenInclude(e => e.Course)
                //andmeid ei salvestata vahemällu ja ei jälgita
                .AsNoTracking()
                //tagastab esimese elemendi andmetest, mis on tingimuses välja toodud
                .FirstOrDefaultAsync(m => m.Id == id);

            var vm = new StudentDetailsViewModel
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate,
                //miks kasutasime ?? - vaikiva väärtuse annab e default väärtus, kui muutuja on tühi (null)
                //või mitte defineeritud. Annab enne vasakpoolse väärtuse, kui see ei ole null. Kui on null,
                //siis annab parempoolse väärtuse.
                EnrollmentsVm = (student.Enrollments ?? Enumerable.Empty<Enrollment>())
                    .Select(x => new EnrollmentViewModel
                    {
                        CourseId = x.CourseId,
                        Grade = x.Grade,
                        CourseVm = new CourseViewModel
                        {
                            CourseId = x.Course?.CourseId ?? 0,
                            Title = x.Course?.Title,
                            Credits = x.Course?.Credits ?? 0
                        }
                    }).ToArray()
            };

            //kui student on null, siis tagastame NotFound() tulemuse
            if (student == null)
            {
                return NotFound();
            }

            //kui student on leitud, siis tagastame View(vm) tulemuse
            return View(vm);
        }

        //GET: Student/Create
        //see meetod tagastab vaate, kus saab luua uue student'i
        public IActionResult Create()
        {
            return View();
        }

        //POST: Student/Create
        //see meetod salvestab uue student'i andmebaasi
        [HttpPost]
        //see meetod on kaitstud CSRF rünnakute eest
        //see meetod on asünkroonene, mis tähendab, et see meetod ei saa
        //olla samaaegselt mitu korda käivitatud
        public async Task<IActionResult> Create(StudentCreateViewModel vm)
        {
            //kui model on valiidne, siis loome uue student'i ja salvestame selle andmebaasi
            if (ModelState.IsValid)
            {
                var student = new Models.Student
                {
                    LastName = vm.LastName,
                    FirstMidName = vm.FirstMidName,
                    EnrollmentDate = vm.EnrollmentDate
                };
                //lisame student'i andmebaasi ja salvestame muudatused
                _context.Add(student);
                //miks kasutame await?
                //kui me kasutame await, siis me ootame kuni salvestamine on lõpetatud
                await _context.SaveChangesAsync();
                //pärast salvestamist suuname kasutaja tagasi Index vaatesse
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            //kui student on null siis on NotFound
            if (student == null)
            {
                return NotFound();
            }
            //tuleb teha domaini modelist andmete ülekanne view modeli omasse
            var update = new StudentUpdateViewModel
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate

            };
            return View(update);

        }
        [HttpPost]
        public async Task<IActionResult> Update(StudentUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var student = new Models.Student
                {
                    Id = vm.Id,
                    LastName = vm.LastName,
                    FirstMidName = vm.FirstMidName,
                    EnrollmentDate = vm.EnrollmentDate
                };
                //lisame student'i andmebaasi ja salvestame muudatused
                _context.Update(student);
                //miks kasutame await?
                //kui me kasutame await, siis me ootame kuni salvestamine on lõpetatud
                await _context.SaveChangesAsync();
                //pärast salvestamist suuname kasutaja tagasi Index vaatesse

                //KUi andmed on uuendatud, siis suunab tagasi Update vaatesse, kus saab kohe uuesti andmeid uuendada.
                //Hetkel suunab Index vaatesse peale uuendust
                return RedirectToAction(nameof(Update));
            }
            return RedirectToAction(nameof(Index));
        }
        //tehke delete Get meetod koos vaatega
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            var vm = new StudentDeleteViewModel
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate,
                EnrollmentsVm = (student.Enrollments ?? Enumerable.Empty<Enrollment>())
                    .Select(x => new EnrollmentViewModel
                    {
                        CourseId = x.CourseId,
                        Grade = x.Grade,
                        CourseVm = new CourseViewModel
                        {
                            CourseId = x.Course?.CourseId ?? 0,
                            Title = x.Course?.Title,
                            Credits = x.Course?.Credits ?? 0
                        }
                    }).ToArray()
            };
            if (student == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                Student delete = new Student()
                {
                    Id = id,
                };
                //teine variant
                //var student = await _context.Students
                //    .FirstOrDefaultAsync(x => x.Id == id);
                _context.Students.Remove(delete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
                throw;
            }
            return RedirectToAction(nameof(Delete));
        }
    }
}
