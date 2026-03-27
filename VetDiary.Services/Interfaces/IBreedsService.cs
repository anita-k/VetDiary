using VetDiary.ViewModels;
using VetDiary.ViewModels.Breed;

namespace VetDiary.Services.Interfaces
{
    public interface IBreedsService
    {
        Task<IEnumerable<BreedIndexViewModel>> GetAllBreedsAsync();

        Task<PaginatedList<BreedIndexViewModel>> GetAllBreedsAsync(int page, int pageSize, string? searchTerm = null);

        Task<BreedDetailsViewModel> GetBreedDetailsByIdAsync(int id);

        Task<BreedCreateViewModel> GetBreedCreateViewModelAsync();

        Task AddBreedAsync(BreedCreateViewModel model);

        Task<BreedEditViewModel> GetBreedForEditAsync(int id);

        Task EditBreedAsync(BreedEditViewModel model);

        Task<BreedDeleteViewModel> GetBreedDeleteDetailsAsync(int id);

        Task DeleteBreedAsync(int id);

        Task<IEnumerable<BreedIndexViewModel>> GetBreedsBySpecies(int speciesId);

    }
}
