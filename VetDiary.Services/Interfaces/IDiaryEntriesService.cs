using VetDiary.ViewModels.DiaryEntry;

namespace VetDiary.Services.Interfaces
{
    public interface IDiaryEntriesService
    {
        Task<IEnumerable<DiaryEntryIndexViewModel>> GetAllDiaryEntriesAsync();

        Task<DiaryEntryDetailsViewModel> GetDiaryEntryDetailsByIdAsync(int id);

        Task<DiaryEntryCreateViewModel> GetDiaryEntryCreateViewModelAsync();

        Task AddDiaryEntryAsync(DiaryEntryCreateViewModel model);

        Task<DiaryEntryEditViewModel> GetDiaryEntryForEditAsync(int id);

        Task EditDiaryEntryAsync(DiaryEntryEditViewModel model);

        Task<DiaryEntryDeleteViewModel> GetDiaryEntryDeleteDetailsAsync(int id);

        Task DeleteDiaryEntryAsync(int id);

    }
}
