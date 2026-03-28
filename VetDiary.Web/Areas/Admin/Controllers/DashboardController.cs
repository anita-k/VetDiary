using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetDiary.Data;
using Microsoft.EntityFrameworkCore;

namespace VetDiary.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalClients = await _context.Clients.CountAsync();
            ViewBag.TotalPets = await _context.Pets.CountAsync();
            ViewBag.TotalDiaryEntries = await _context.DiaryEntries.CountAsync();
            ViewBag.TotalSpecies = await _context.Species.CountAsync();
            ViewBag.TotalBreeds = await _context.Breeds.CountAsync();
            ViewBag.TotalVisitReasons = await _context.VisitReasons.CountAsync();

            return View();
        }
    }
}
