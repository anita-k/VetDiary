using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels.Client;

namespace VetDiary.Controllers
{
    public class ClientsController : BaseController
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        // GET: Clients
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var clients = await _clientsService.GetAllClientsAsync();
            return View(clients);
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
            return RedirectToAction(nameof(Index));
        }

    }
}
