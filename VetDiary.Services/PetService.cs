using VetDiary.Services.Interfaces;
using VetDiary.ViewModels.Pet;

namespace VetDiary.Services
{
    public class PetsService : IPetsService
    {
        public Task AddPetAsync(PetCreateViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeletePetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPetAsync(PetEditViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PetIndexViewModel>> GetAllPetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PetCreateViewModel> GetPetCreateViewModelAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PetDeleteViewModel> GetPetDeleteDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PetDetailsViewModel> GetPetDetailsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PetEditViewModel> GetPetForEditAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}