using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaternLab.Models;
using PaternLab.Service.GenericRepository;

namespace PaternLab.Controllers
{
    public class PatientExaminationsController : Controller
    {
        private readonly IGenericRepository<PatientExamination> _genericRepository;

        public PatientExaminationsController(IGenericRepository<PatientExamination> genericRepository)
        {
            _genericRepository = genericRepository;

        }

        // GET: PatientExaminations
        public async Task<IActionResult> Index()
        {
            return View(await _genericRepository.GetAll());
        }

        // GET: PatientExaminations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientExamination = await _genericRepository.GetById(id);

            if (patientExamination == null)
            {
                return NotFound();
            }

            return View(patientExamination);
        }

        // GET: PatientExaminations/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PassedDate,Passed,Result")] PatientExamination patientExamination)
        {
            if (ModelState.IsValid)
            {
                patientExamination.PassedDate = patientExamination.PassedDate.ToUniversalTime();

                await _genericRepository.Insert(patientExamination);
                await _genericRepository.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(patientExamination);
        }

        // GET: PatientExaminations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientExamination = await _genericRepository.GetById(id);
            if (patientExamination == null)
            {
                return NotFound();
            }
            return View(patientExamination);
        }

        // POST: PatientExaminations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PassedDate,Passed,Result")] PatientExamination patientExamination)
        {
            if (id != patientExamination.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    patientExamination.PassedDate = patientExamination.PassedDate.ToUniversalTime();
                    _genericRepository.Update(patientExamination);
                    await _genericRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var existPatientExamination = await _genericRepository.GetById(patientExamination.Id);

                    if (existPatientExamination == null)
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
            return View(patientExamination);
        }

        // GET: PatientExaminations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientExamination = await _genericRepository.GetById(id);
            if (patientExamination == null)
            {
                return NotFound();
            }

            return View(patientExamination);
        }

        // POST: PatientExaminations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientExamination = await _genericRepository.GetById(id);
            if (patientExamination != null)
            {
                _genericRepository.Delete(patientExamination);
            }

            await _genericRepository.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
