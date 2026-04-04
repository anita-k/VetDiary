using VetDiary.ViewModels;
using VetDiary.ViewModels.Species;

namespace VetDiary.Services.Interfaces
{
    public interface ISpeciesService
    {
        Task<IEnumerable<SpeciesIndexViewModel>> GetAllSpeciesAsync();

        Task<PaginatedList<SpeciesIndexViewModel>> GetAllSpeciesAsync(int page, int pageSize, string? searchTerm = null, string? sortBy = null, bool sortDesc = false);

        Task<SpeciesDetailsViewModel> GetSpeciesDetailsByIdAsync(int id);

        Task<SpeciesCreateViewModel> GetSpeciesCreateViewModelAsync();

        Task AddSpeciesAsync(SpeciesCreateViewModel model);

        Task<SpeciesEditViewModel> GetSpeciesForEditAsync(int id);

        Task EditSpeciesAsync(SpeciesEditViewModel model);

        Task<SpeciesDeleteViewModel> GetSpeciesDeleteDetailsAsync(int id);

        Task DeleteSpeciesAsync(int id);

    }
}
