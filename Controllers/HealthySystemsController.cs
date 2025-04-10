using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaternLab.Context;
using PaternLab.Models;

namespace PaternLab.Controllers
{
    public class HealthySystemsController : Controller
    {
        private readonly AppDbContext _context;

        public HealthySystemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: HealthySystems
        public async Task<IActionResult> Index()
        {
            return View(await _context.HealthySystem.ToListAsync());
        }

        // GET: HealthySystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthySystem = await _context.HealthySystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthySystem == null)
            {
                return NotFound();
            }

            return View(healthySystem);
        }

        // GET: HealthySystems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HealthySystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPatient,IdDoctor")] HealthySystem healthySystem)
        {
            Console.WriteLine("Insert _____________________");

            if (ModelState.IsValid)
            {
                _context.Add(healthySystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(healthySystem);
        }

        // GET: HealthySystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthySystem = await _context.HealthySystem.FindAsync(id);
            if (healthySystem == null)
            {
                return NotFound();
            }
            return View(healthySystem);
        }

        // POST: HealthySystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPatient,IdDoctor")] HealthySystem healthySystem)
        {
            if (id != healthySystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthySystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthySystemExists(healthySystem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(healthySystem);
        }

        // GET: HealthySystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthySystem = await _context.HealthySystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthySystem == null)
            {
                return NotFound();
            }

            return View(healthySystem);
        }

        // POST: HealthySystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var healthySystem = await _context.HealthySystem.FindAsync(id);
            if (healthySystem != null)
            {
                _context.HealthySystem.Remove(healthySystem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthySystemExists(int id)
        {
            return _context.HealthySystem.Any(e => e.Id == id);
        }
    }
}
