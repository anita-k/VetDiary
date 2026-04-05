using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels.Client;
using VetDiary.Web.Hubs;

namespace VetDiary.Controllers
{
    public class ClientsController : BaseController
    {
        private readonly IClientsService _clientsService;
        private readonly IHubContext<DashboardHub> _dashboardHub;

        public ClientsController(IClientsService clientsService, IHubContext<DashboardHub> dashboardHub)
        {
            _clientsService = clientsService;
            _dashboardHub = dashboardHub;
        }

        // GET: Clients
        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1, string? searchTerm = null, string? sortBy = null, bool sortDesc = false)
        {
            const int pageSize = 10;
            var clients = await _clientsService.GetAllClientsAsync(page, pageSize, searchTerm, sortBy, sortDesc);
            ViewBag.PageIndex = clients.PageIndex;
            ViewBag.TotalPages = clients.TotalPages;
            ViewBag.HasPreviousPage = clients.HasPreviousPage;
            ViewBag.HasNextPage = clients.HasNextPage;
            ViewBag.SearchTerm = searchTerm;
            ViewBag.SortBy = sortBy;
            ViewBag.SortDesc = sortDesc;
            return View(clients.Items);
        }

        // GET: Clients/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var client = await _clientsService.GetClientDetailsByIdAsync((int)id);
                return View(client);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientCreateViewModel client)
        {
            if (ModelState.IsValid)
            {
                await _clientsService.AddClientAsync(client);
                await _dashboardHub.Clients.All.SendAsync("RefreshDashboard");
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var breed = await _clientsService.GetClientForEditAsync((int)id);
            if (breed == null)
            {
                return NotFound();
            }
            return View(breed);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClientEditViewModel client)
        {
            if (ModelState.IsValid)
            {
                await _clientsService.EditClientAsync(client);
                await _dashboardHub.Clients.All.SendAsync("RefreshDashboard");
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var breed = await _clientsService.GetClientDeleteDetailsAsync((int)id);
            if (breed == null)
            {
                return NotFound();
            }
            return View(breed);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clientsService.DeleteClientAsync(id);
            await _dashboardHub.Clients.All.SendAsync("RefreshDashboard");
            return RedirectToAction(nameof(Index));
        }

    }
}
