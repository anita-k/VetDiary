using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VetDiary.Data;
using VetDiary.Data.Models;
using VetDiary.Services;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels.Breed;
using VetDiary.ViewModels.Pet;

namespace VetDiary.Controllers
{
    public class PetsController : BaseController
    {
        private readonly IPetsService _petsService;

        public PetsController(IPetsService petsService)
        {
            _petsService = petsService;
        }

        // GET: Pets
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var pets = await _petsService.GetAllPetsAsync();
            return View(pets);
        }

        // GET: Pets/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var pet = await _petsService.GetPetDetailsByIdAsync((int)id);
                return View(pet);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        // GET: Pets/Create
        public async Task<IActionResult> Create(int? clientId)
        {            
            var pet = await _petsService.GetPetCreateViewModelAsync();
            return View(pet);
        }

        // POST: Pets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetCreateViewModel pet)
        {
             if (ModelState.IsValid)
            {
                await _petsService.AddPetAsync(pet);

                return RedirectToAction(nameof(Index));
            }

            var model = await _petsService.GetPetCreateViewModelAsync();
            pet.Clients = model.Clients;
            pet.Species = model.Species;
            pet.Breeds = model.Breeds;
            return View(pet);
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pet = await _petsService.GetPetForEditAsync((int)id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        // POST: Pets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PetEditViewModel pet)
        {
            if (ModelState.IsValid)
            {
                await _petsService.EditPetAsync(pet);
                return RedirectToAction(nameof(Index));
            }
            var model = await _petsService.GetPetForEditAsync(pet.Id);
            pet.Breeds = model.Breeds;
            pet.Species = model.Species;
            pet.Clients = model.Clients;

            return View(pet);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pet = await _petsService.GetPetDeleteDetailsAsync((int)id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _petsService.DeletePetAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                // Check if the inner exception is a SqlException and look for the Conflict error code
                if (ex.InnerException is SqlException sqlEx && (sqlEx.Number == 547))
                {
                    ModelState.AddModelError(string.Empty, "");

                    // Return to the view with the error message
                    var pet = await _petsService.GetPetDeleteDetailsAsync((int)id);
                    if (pet == null)
                    {
                        return NotFound();
                    }
                    ViewBag.ErrorMessage = "You cannot delete this pet because it has related diary entries. Please delete the entries first.";
                    return View(pet);
                }

                // If it's some other error, re-throw or handle generally
                throw;
            }

        }

    }
}
