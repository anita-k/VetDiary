using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VetDiary.Data;
using VetDiary.Data.Models;
using VetDiary.Services.Interfaces;

namespace VetDiary.Controllers
{
    public class VisitReasonsController : Controller
    {
        private readonly IVisitReasonsService _visitReasonsService;
        //TODO: TO REMOVE WHEN SERVICE IS FULLY READY
        private readonly ApplicationDbContext _context;

        //TODO: TO REMOVE WHEN SERVICE IS FULLY READY
        public VisitReasonsController(
            ApplicationDbContext context, 
            IVisitReasonsService visitReasonsService
            )
        {
            _context = context;
            _visitReasonsService = visitReasonsService;
        }

        // GET: VisitReasons
        public async Task<IActionResult> Index()
        {
            var visitReasons = await _visitReasonsService.GetAllVisitReasonsAsync();
            return View(visitReasons);
        }

        // GET: VisitReasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var visitReason = await _visitReasonsService.GetVisitReasonDetailsByIdAsync((int)id);
            return View(visitReason);
        }

        // GET: VisitReasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VisitReasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] VisitReason visitReason)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitReason);
                await _context.SaveChangesAsync();
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

            var visitReason = await _context.VisitReasons.FindAsync(id);
            if (visitReason == null)
            {
                return NotFound();
            }
            return View(visitReason);
        }

        // POST: VisitReasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] VisitReason visitReason)
        {
            if (id != visitReason.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitReason);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitReasonExists(visitReason.Id))
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
            return View(visitReason);
        }

        private bool VisitReasonExists(int id)
        {
            return _context.VisitReasons.Any(e => e.Id == id);
        }
    }
}
