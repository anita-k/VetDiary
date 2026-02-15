using VetDiary.Data;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels.DiaryEntry;
using VetDiary.ViewModels.Pet;

namespace VetDiary.Services
{
    public class DiaryEntriesService : IDiaryEntriesService
    {

        private readonly ApplicationDbContext _context;

        public DiaryEntriesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddDiaryEntryAsync(DiaryEntryCreateViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDiaryEntryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task EditDiaryEntryAsync(DiaryEntryEditViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DiaryEntryIndexViewModel>> GetAllDiaryEntryAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<DiaryEntryCreateViewModel> GetDiaryEntryCreateViewModelAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<DiaryEntryDeleteViewModel> GetDiaryEntryDeleteDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DiaryEntryDetailsViewModel> GetDiaryEntryDetailsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DiaryEntryEditViewModel> GetDiaryEntryForEditAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}