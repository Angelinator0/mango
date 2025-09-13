using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;

namespace StudentPortal.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;
        public StudentController(AppDbContext db) => _db = db;

        // READ (список)
        public async Task<IActionResult> Index()
        {
            var data = await _db.Students.AsNoTracking().ToListAsync();
            return View(data);
        }

        // CREATE GET
        public IActionResult Create() => View(new Student());

        // CREATE POST
        [HttpPost]
        public async Task<IActionResult> Create(Student model)
        {
            if (!ModelState.IsValid) return View(model);
            _db.Students.Add(model);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // EDIT GET
        public async Task<IActionResult> Edit(int id)
        {
            var s = await _db.Students.FindAsync(id);
            if (s == null) return NotFound();
            return View(s);
        }

        // EDIT POST
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Student model)
        {
            if (id != model.Id) return NotFound();
            if (!ModelState.IsValid) return View(model);

            _db.Update(model);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}