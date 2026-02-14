using Microsoft.AspNetCore.Mvc;
using VetDiary.Data.Models;
using VetDiary.Services;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels.Breed;

namespace VetDiary.Controllers
{
    public class BreedsController : Controller
    {
        private readonly IBreedsService _breedsService;

        public BreedsController(IBreedsService breedsService)
        {
            _breedsService = breedsService;
        }

        // GET: Breeds
        public async Task<IActionResult> Index()
        {
            var breeds = await _breedsService.GetAllBreedsAsync();
            return View(breeds);
        }

        // GET: Breeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var breed = await _breedsService.GetBreedDetailsByIdAsync((int)id);
                return View(breed);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        // GET: Breeds/Create
        public async Task<IActionResult> Create()
        {
            var breed = await _breedsService.GetBreedCreateViewModelAsync();
            return View(breed);
        }

        // POST: Breeds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BreedCreateViewModel breed)
        {
            if (ModelState.IsValid)
            {
                await _breedsService.AddBreedAsync(breed);

                return RedirectToAction(nameof(Index));
            }
            return View(breed);
        }

        // GET: Breeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var breed = await _breedsService.GetBreedForEditAsync((int)id);
            if (breed == null)
            {
                return NotFound();
            }
            return View(breed);
        }

        // POST: Breeds/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BreedEditViewModel breed)
        {
            if (ModelState.IsValid)
            {
                await _breedsService.EditBreedAsync(breed);
                return RedirectToAction(nameof(Index));
            }
            return View(breed);
        }

        // GET: Breeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var breed = await _breedsService.GetBreedDeleteDetailsAsync((int)id);
            if (breed == null)
            {
                return NotFound();
            }

            return View(breed);
        }

        // POST: Breeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _breedsService.DeleteBreedAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
