using Microsoft.EntityFrameworkCore;
using VetDiary.Data;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels;

namespace VetDiary.Services
{
    public class VisitReasonsService : IVisitReasonsService
    {
        private readonly ApplicationDbContext _context;

        public VisitReasonsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<VisitReasonViewModel>> GetAllVisitReasonsAsync()
        {
            return await _context.VisitReasons.Select(vr => new VisitReasonViewModel
            {
                Id = vr.Id,
                Name = vr.Name,
            })
            .ToListAsync();
        }

        public async Task<VisitReasonViewModel> GetVisitReasonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VisitReasonCreateViewModel> GetVisitReasonCreateViewModelAsync()
        {
            throw new NotImplementedException { };
        }

        public async Task SaveVisitReasonAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VisitReasonViewModel> GetVisitReasonDetailsByIdAsync(int id)
        {
            var visitReason = await _context.VisitReasons
                .FirstOrDefaultAsync(vr => vr.Id == id);

            if (visitReason == null)
            {
                throw new InvalidOperationException("Not found");
            }

            return new VisitReasonViewModel
            {
                Id = visitReason.Id,
                Name = visitReason.Name,
            };
        }

        public async Task<VisitReasonViewModel> GetVisitReasonForEditAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task EditVisitReasonAsync(VisitReasonViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveVisitReasonAsync(int id)
        {
            throw new NotImplementedException();
        }


    }
}