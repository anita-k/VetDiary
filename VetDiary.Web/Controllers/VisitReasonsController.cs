using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels.VisitReason;
using VetDiary.Web.Hubs;

namespace VetDiary.Controllers
{
    public class VisitReasonsController : BaseController
    {
        private readonly IVisitReasonsService _visitReasonsService;
        private readonly IHubContext<DashboardHub> _dashboardHub;

        public VisitReasonsController(
            IVisitReasonsService visitReasonsService,
            IHubContext<DashboardHub> dashboardHub
            )
        {
            _visitReasonsService = visitReasonsService;
            _dashboardHub = dashboardHub;
        }

        // GET: VisitReasons
        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1, string? searchTerm = null, string? sortBy = null, bool sortDesc = false)
        {
            const int pageSize = 10;
            var visitReasons = await _visitReasonsService.GetAllVisitReasonsAsync(page, pageSize, searchTerm, sortBy, sortDesc);
            ViewBag.PageIndex = visitReasons.PageIndex;
            ViewBag.TotalPages = visitReasons.TotalPages;
            ViewBag.HasPreviousPage = visitReasons.HasPreviousPage;
            ViewBag.HasNextPage = visitReasons.HasNextPage;
            ViewBag.SearchTerm = searchTerm;
            ViewBag.SortBy = sortBy;
            ViewBag.SortDesc = sortDesc;
            return View(visitReasons.Items);
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
                await _dashboardHub.Clients.All.SendAsync("RefreshDashboard");
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
                await _dashboardHub.Clients.All.SendAsync("RefreshDashboard");
                return RedirectToAction(nameof(Index));
            }
            return View(visitReason);
        }
    }
}
