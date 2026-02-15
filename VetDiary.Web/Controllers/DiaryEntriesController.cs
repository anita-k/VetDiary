using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetDiary.Data;
using VetDiary.Data.Models;
using VetDiary.Services;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels.DiaryEntry;
using VetDiary.ViewModels.Pet;

namespace VetDiary.Controllers
{
    public class DiaryEntriesController : BaseController
    {
        private readonly IDiaryEntriesService _diaryEntryService;

        public DiaryEntriesController(IDiaryEntriesService diaryentryService)
        {
            _diaryEntryService = diaryentryService;
        }

        // GET: DiaryEntries
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {            
            var diaryEntries = await _diaryEntryService.GetAllDiaryEntriesAsync();
            return View(diaryEntries);
        }

        // GET: DiaryEntries/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var diaryEntry = await _diaryEntryService.GetDiaryEntryDetailsByIdAsync((int)id);
                return View(diaryEntry);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        // GET: DiaryEntries/Create
        public async Task<IActionResult> Create(int? petId)
        {
            var diaryEntry = await _diaryEntryService.GetDiaryEntryCreateViewModelAsync();
            return View(diaryEntry);
        }

        // POST: DiaryEntries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DiaryEntryCreateViewModel diaryEntry)
        {
            if (ModelState.IsValid)
            {
                await _diaryEntryService.AddDiaryEntryAsync(diaryEntry);

                return RedirectToAction(nameof(Index));
            }
            var model = await _diaryEntryService.GetDiaryEntryCreateViewModelAsync();
            diaryEntry.Pets = model.Pets;
            diaryEntry.VisitReasons = model.VisitReasons;
            return View(diaryEntry);
        }

        // GET: DiaryEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var diaryEntry = await _diaryEntryService.GetDiaryEntryForEditAsync((int)id);
            if (diaryEntry == null)
            {
                return NotFound();
            }
            return View(diaryEntry);
        }

        // POST: DiaryEntries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DiaryEntryEditViewModel diaryEntry)
        {
            if (ModelState.IsValid)
            {
                await _diaryEntryService.EditDiaryEntryAsync(diaryEntry);
                return RedirectToAction(nameof(Index));
            }
            return View(diaryEntry);
        }

        // GET: DiaryEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var breed = await _diaryEntryService.GetDiaryEntryDeleteDetailsAsync((int)id);
            if (breed == null)
            {
                return NotFound();
            }

            return View(breed);
        }

        // POST: DiaryEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _diaryEntryService.DeleteDiaryEntryAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
