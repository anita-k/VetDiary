using Microsoft.EntityFrameworkCore;
using VetDiary.Data;
using VetDiary.Data.Models;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels;
using VetDiary.ViewModels.VisitReason;

namespace VetDiary.Services
{
    public class VisitReasonsService : IVisitReasonsService
    {
        private readonly ApplicationDbContext _context;

        public VisitReasonsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VisitReasonIndexViewModel>> GetAllVisitReasonsAsync()
        {
            return await _context.VisitReasons.Select(vr => new VisitReasonIndexViewModel
            {
                Id = vr.Id,
                Name = vr.Name,
            })
            .ToListAsync();
        }

        public async Task<PaginatedList<VisitReasonIndexViewModel>> GetAllVisitReasonsAsync(int page, int pageSize, string? searchTerm = null)
        {
            var query = _context.VisitReasons.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(v => v.Name.Contains(searchTerm));
            }

            var count = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(vr => new VisitReasonIndexViewModel
                {
                    Id = vr.Id,
                    Name = vr.Name,
                })
                .ToListAsync();

            return new PaginatedList<VisitReasonIndexViewModel>(items, count, page, pageSize);
        }

        public async Task<VisitReasonDetailsViewModel> GetVisitReasonDetailsByIdAsync(int id)
        {
            var visitReason = await _context.VisitReasons
                .FirstOrDefaultAsync(vr => vr.Id == id);

            if (visitReason == null)
            {
                throw new InvalidOperationException("Not found");
            }

            return new VisitReasonDetailsViewModel
            {
                Id = visitReason.Id,
                Name = visitReason.Name,
            };
        }

        public async Task<VisitReasonCreateViewModel> GetVisitReasonCreateViewModelAsync()
        {
            throw new NotImplementedException { };
        }

        public async Task AddVisitReasonAsync(VisitReasonCreateViewModel model)
        {
            var visitReason = new VisitReason
            {
                Name = model.Name,
            };

            _context.VisitReasons.Add(visitReason);
            await _context.SaveChangesAsync();
        }

        public async Task<VisitReasonEditViewModel> GetVisitReasonForEditAsync(int id)
        {
            var visitReason = await _context.VisitReasons.FirstOrDefaultAsync(r => r.Id == id);

            if (visitReason == null)
            {
                throw new ArgumentException("Visit Reason not found.");
            }

            return new VisitReasonEditViewModel
            {
                Name = visitReason.Name,
            };
        }

        public async Task EditVisitReasonAsync(VisitReasonEditViewModel model)
        {
                var visitReason = await _context.VisitReasons.FirstOrDefaultAsync(r => r.Id == model.Id);
                if (visitReason == null)
                {
                    throw new ArgumentException("Visit Reason not found.");
                }
                visitReason.Name = model.Name;
                await _context.SaveChangesAsync();
        }

    }
}