using Microsoft.AspNetCore.Mvc;
using University.Data;
using Microsoft.EntityFrameworkCore;
using University.ViewModel;

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
            //leiame kõik student id-d ja teisendame need StudentIndexViewModel'iks
            //miks peab kasutama await?
            //kui me kasutame await, siis me ootame kuni päring on lõpetatud
            //ja saame tulemuse, enne kui me jätkame koodi kirjutamist
            // var data = await _context.Students.ToListAsync();
            var result = _context.Students
                .Select(s => new ViewModel.StudentIndexViewModel
            {
                Id = s.Id,
                LastName = s.LastName,
                FirstMidName = s.FirstMidName,
                EnrollmentDate = s.EnrollmentDate
            }).ToListAsync();

            return View(result);
        }
        public async Task<IActionResult> Details(int? id)
        {
            //kui student on null siis tagastame NotFound() tulemuse
            if (id == null)
            {
                return NotFound();
            }
            //leiame student id järgi
            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);

            var vm = new ViewModel.StudentDetailsViewModel
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate
            };

            //kui student on null, siis tagastame NotFound() tulemuse
            if (student == null)
            {
                return NotFound();
            }
            //kui student on leitud, siis tagastame View(student) tulemuse
            return View(vm);
        }
        
        public IActionResult Create()
        {

            return View();
        }
        //POST: Student/Create
        //see meetod salvestab uue student'i andmebaasi
        [HttpPost]
        //see meetod on kaitsud CSRF rünnakute eest
        //see meetod on asünkroonne, mis tähendab et see meeod ei saa
        //olla samaageselt mitu korda käivitatud
        public async Task<IActionResult> Create(StudentCreateViewModel vm)
        {
            //kui model on valiidne, siis loome uue Student'i ja salvestame selle andmebaasi
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
                //miks kasutame await
                //kui me kasutame await, siis me ootame kuni salvestamine on lõpetatud
                await _context.SaveChangesAsync();
                //pärast salvestamist suuname kasutaja tagasi Index vaatesse
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
    }
}
