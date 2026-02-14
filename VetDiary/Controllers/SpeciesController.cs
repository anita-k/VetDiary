using Microsoft.AspNetCore.Mvc;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels.Species;

namespace VetDiary.Controllers
{
    public class SpeciesController : Controller
    {
        private readonly ISpeciesService _speciesService;

        public SpeciesController(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        // GET: Species
        public async Task<IActionResult> Index()
        {
            var species = await _speciesService.GetAllSpeciesAsync();
            return View(species);
        }

        // GET: Species/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var species = await _speciesService.GetSpeciesDetailsByIdAsync((int)id);
                return View(species);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        // GET: Species/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Species/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpeciesCreateViewModel species)
        {
            if (ModelState.IsValid)
            {

                await _speciesService.AddSpeciesAsync(species);

                return RedirectToAction(nameof(Index));
            }
            return View(species);
        }

        // GET: Species/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var species = await _speciesService.GetSpeciesForEditAsync((int)id);
            if (species == null)
            {
                return NotFound();
            }
            return View(species);
        }

        // POST: Species/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpeciesEditViewModel species)
        {
            if (ModelState.IsValid)
            {
                await _speciesService.EditSpeciesAsync(species);
                return RedirectToAction(nameof(Index));
            }
            return View(species);
        }

        // GET: Species/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var species = await _speciesService.GetSpeciesForEditAsync((int)id);
            if (species == null)
            {
                return NotFound();
            }

            return View(species);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _speciesService.DeleteSpeciesAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
