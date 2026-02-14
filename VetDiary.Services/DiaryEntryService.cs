using VetDiary.Services.Interfaces;
using VetDiary.ViewModels.DiaryEntry;
using VetDiary.ViewModels.Pet;

namespace VetDiary.Services
{
    public class DiaryEntriesService : IDiaryEntriesService
    {
        public Task AddDiaryEntryAsync(DiaryEntryCreateViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDiaryEntryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditDiaryEntryAsync(DiaryEntryEditViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DiaryEntryIndexViewModel>> GetAllDiaryEntryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DiaryEntryCreateViewModel> GetDiaryEntryCreateViewModelAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DiaryEntryDeleteViewModel> GetDiaryEntryDeleteDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DiaryEntryDetailsViewModel> GetDiaryEntryDetailsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DiaryEntryEditViewModel> GetDiaryEntryForEditAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}