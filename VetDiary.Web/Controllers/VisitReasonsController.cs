using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels.VisitReason;

namespace VetDiary.Controllers
{
    public class VisitReasonsController : BaseController
    {
        private readonly IVisitReasonsService _visitReasonsService;

        public VisitReasonsController(
            IVisitReasonsService visitReasonsService
            )
        {
            _visitReasonsService = visitReasonsService;
        }

        // GET: VisitReasons
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var visitReasons = await _visitReasonsService.GetAllVisitReasonsAsync();
            return View(visitReasons);
        }

        // GET: VisitReasons/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var visitReason = await _visitReasonsService.GetVisitReasonDetailsByIdAsync((int)id);
                return View(visitReason);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        // GET: VisitReasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VisitReasons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VisitReasonCreateViewModel visitReason)
        {
            if (ModelState.IsValid)
            {

                await _visitReasonsService.AddVisitReasonAsync(visitReason);

                return RedirectToAction(nameof(Index));
            }
            return View(visitReason);
        }

        // GET: VisitReasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var visitReason = await _visitReasonsService.GetVisitReasonForEditAsync((int)id);
            return View(visitReason);
        }

        // POST: VisitReasons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VisitReasonEditViewModel visitReason)
        {
            if (ModelState.IsValid)
            {
                await _visitReasonsService.EditVisitReasonAsync(visitReason);
                return RedirectToAction(nameof(Index));
            }
            return View(visitReason);
        }


    }
}
