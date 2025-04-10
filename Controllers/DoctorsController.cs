using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaternLab.Models;
using PaternLab.Service.GenericRepository;

namespace PaternLab.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IGenericRepository<Doctor> _genericRepository;

        public DoctorsController(IGenericRepository<Doctor> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            return View(await _genericRepository.GetAll());
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _genericRepository.GetById(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Experience,FieldActivity,FullName,Email,Age")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _genericRepository.Insert(doctor);
                await _genericRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _genericRepository.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Experience,FieldActivity,FullName,Email,Age")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _genericRepository.Update(doctor);
                    await _genericRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var doctorExist = await _genericRepository.GetById(id);
                    if (doctorExist == null)
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
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _genericRepository.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _genericRepository.GetById(id);
            if (doctor != null)
            {
                _genericRepository.Delete(doctor);
            }

            await _genericRepository.Save();
            return RedirectToAction(nameof(Index));
        }


    }
}
