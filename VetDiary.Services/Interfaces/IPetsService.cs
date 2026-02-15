using VetDiary.ViewModels.Pet;

namespace VetDiary.Services.Interfaces
{
    public interface IPetsService
    {
        Task<IEnumerable<PetIndexViewModel>> GetAllPetsAsync();

        Task<PetDetailsViewModel> GetPetDetailsByIdAsync(int id);

        Task<PetCreateViewModel> GetPetCreateViewModelAsync();

        Task AddPetAsync(PetCreateViewModel model);

        Task<PetEditViewModel> GetPetForEditAsync(int id);

        Task EditPetAsync(PetEditViewModel model);

        Task<PetDeleteViewModel> GetPetDeleteDetailsAsync(int id);

        Task DeletePetAsync(int id);

    }
}
