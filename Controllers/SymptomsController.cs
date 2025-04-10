using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaternLab.Models;
using PaternLab.Service.GenericRepository;

namespace PaternLab.Controllers
{
    public class SymptomsController : Controller
    {
        private readonly IGenericRepository<Symptom> _genericRepository;

        public SymptomsController(IGenericRepository<Symptom> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        // GET: Symptoms
        public async Task<IActionResult> Index()
        {
            return View(await _genericRepository.GetAll());
        }

        // GET: Symptoms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var symptom = await _genericRepository.GetById(id);

            if (symptom == null)
            {
                return NotFound();
            }

            return View(symptom);
        }

        // GET: Symptoms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Symptoms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPatient,Name")] Symptom symptom)
        {
            if (ModelState.IsValid)
            {
                _genericRepository.Insert(symptom);
                await _genericRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(symptom);
        }

        // GET: Symptoms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var symptom = await _genericRepository.GetById(id);
            if (symptom == null)
            {
                return NotFound();
            }
            return View(symptom);
        }

        // POST: Symptoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPatient,Name")] Symptom symptom)
        {
            if (id != symptom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _genericRepository.Update(symptom);
                    await _genericRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var symptomExist = await _genericRepository.GetById(id);
                    if (symptomExist == null)
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
            return View(symptom);
        }

        // GET: Symptoms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var symptom = await _genericRepository.GetById(id);
            if (symptom == null)
            {
                return NotFound();
            }

            return View(symptom);
        }

        // POST: Symptoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var symptom = await _genericRepository.GetById(id);
            if (symptom != null)
            {
                _genericRepository.Delete(symptom);
            }

            await _genericRepository.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
